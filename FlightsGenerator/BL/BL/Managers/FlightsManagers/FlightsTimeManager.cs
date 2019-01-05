using Common.Interfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace BL.Managers.FlightsManagers
{
    /// <summary>
    /// Handles the incoming and starting flights.
    /// </summary>
    public class FlightsTimeManager : IFlightsTimeManager
    {
        #region Private fields

        private event TimerElapsedEventHandler TimerEventHandler;

        private LinkedList<FlightModel> _flightTimeModels;

        private object _lockObject;

        private Timer _timer;
        
        private double _intervalSeconds;

        #endregion


        /// <summary>
        /// Return the timer interval set by the timer.
        /// </summary>
        /// <returns>The number of milliseconds until the timer elapsing</returns>
        public double GetInterval()
        {
            return _intervalSeconds;
        }


        /// <summary>
        /// Property for easy access the first flight in the linked list.
        /// </summary>
        private FlightModel First
        {
            get
            {
                if (_flightTimeModels.First != null)
                    return _flightTimeModels.First.Value;
                else
                    return null;
            }
        }


        /// <summary>
        /// Constructor.
        /// </summary>
        public FlightsTimeManager()
        {
            SetManagerFields();
        }


        /// <summary>
        /// Constructor initializing helper.
        /// </summary>
        private void SetManagerFields()
        {
            _flightTimeModels = new LinkedList<FlightModel>();

            _lockObject = new object();
        }



        /// <summary>
        /// Adds a flight to the time pueue.
        /// </summary>
        /// <param name="flight">The FlightModel instance to add the the time manager queue.</param>
        public void Add(FlightModel flight)
        {
            lock (_lockObject)
            {
                if (IsFirstOrEarlier(flight))
                {
                    if (_timer != null)
                    {
                        KillTimer();
                    }
                    _flightTimeModels.AddFirst(flight);
                    SetTimer();
                    _timer.Start();
                }
                else
                {
                    var tmp = _flightTimeModels.First;
                    while (NextNodeIsntNullOrEarlier(flight, tmp))
                    {
                        tmp = tmp.Next;
                    }
                    _flightTimeModels.AddAfter(tmp, flight);

                }
            }
        }



        /// <summary>
        /// Check if the flights is first in the list or earlier than the first.
        /// </summary>
        /// <param name="flight">The flight being added</param>
        /// <returns></returns>
        private bool IsFirstOrEarlier(FlightModel flight)
        {
            //lock (_lockObject)
            {
                return _flightTimeModels.First == null || First.CompareTo(flight) > 0;
            }
        }



        /// <summary>
        /// Check if the node.Next!=null and thats its flight.Time is earlier then the flight being added.
        /// </summary>
        /// <param name="flight">The flight being added</param>
        /// <param name="node">The node being checked</param>
        /// <returns>If its true or false</returns>
        private  bool NextNodeIsntNullOrEarlier(FlightModel flight, LinkedListNode<FlightModel> node)
        {
            return node.Next != null && node.Next.Value.CompareTo(flight) < 0;
        }




        /// <summary>
        /// Stopping and dispossing the timer.
        /// </summary>
        private void KillTimer()
        {
            _timer.Stop();
            _timer.Elapsed -= TimerElapsed;
            _timer.Dispose();
        }



        /// <summary>
        /// Initialize the timer.
        /// </summary>
        private void SetTimer()
        {
            _timer = new Timer();

            _timer.Elapsed += TimerElapsed;

            _timer.AutoReset = false;

            var interval = First.Time.Subtract(DateTime.Now);
            if (interval.TotalSeconds <= 0)
            {
                interval = new TimeSpan(0, 0, 1);
            }
            _intervalSeconds = Math.Round(interval.TotalSeconds);
            _timer.Interval = interval.TotalMilliseconds;
            
        }


        /// <summary>
        /// The function occured when the timer elapsed.
        /// </summary>
        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {

            KillTimer();

            FlightModel flight = First;
            if (flight != null)
            {
                OnTimerElapsed(flight);
            }
            

        }



        /// <summary>
        /// Passing subscribers the flight that need to enter the base station.
        /// </summary>
        /// <param name="flight"></param>
        private void OnTimerElapsed(FlightModel flight)
        {
            TimerEventHandler?.Invoke(flight);
        }



        /// <summary>
        /// Notify the manager that the flight entered the base staion and rempove it from the list.
        /// </summary>
        public void EnterBaseStation()
        {
            lock (_lockObject)
            {
                _flightTimeModels.Remove(First);
                if (First != null)
                {
                    SetTimer();
                    _timer.Start();
                }
            }
        }



        /// <summary>
        /// Returns the ID of the first flight in the queue.
        /// </summary>
        public int GetFirstId()
        {
            return First.ID;
        }




        /// <summary>
        /// Register a function to be called when timer elapsed.
        /// </summary>
        /// /// <param name="onTimerElapsed">The TimerElapsedEventHandler function registering the flight event.</param>
        public void RegisterToTimerElapsedEvent(TimerElapsedEventHandler onTimerElapsed)
        {
            TimerEventHandler += onTimerElapsed;
        }


        /// <summary>
        /// Returns the timer.
        /// </summary>
        /// <returns></returns>
        public Timer GetTimer()
        {
            return _timer;
        }


        /// <summary>
        /// Returns the number of flight in the queue.
        /// </summary>
        public int GetFlightsCount()
        {
            return _flightTimeModels.Count();
        }
    }
}
