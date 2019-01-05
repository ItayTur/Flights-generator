using Common.Dtos;
using Common.Enums;
using Common.Models;
using Microsoft.AspNet.SignalR.Client;
using RadarFlight.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;

namespace RadarFlight.ViewModels
{
    public class RadarViewModel
    {
        private bool inAction { get; set; }           
        private readonly Object lockObj = new object();
        private CoreApplicationView curentView;
        private const string apiUrl = "http://localhost:53028/api/Flights";

        private static readonly HttpClient client = new HttpClient();

        private HubConnection hubConnection;

        private IHubProxy hubProxy;
        private int horizontalCells;
        private int verticalCells;
        private int plainSize;
        private int stationSize;
        private List<StationToViewModel> stationImages;
        private List<FlightToViewModel> flightImages;
        private Canvas viewCanvas;

        private List<MovementModel> movesList;

        private List<StationModel> StationsList { get; set; }

        public ObservableCollection<FlightModel> FlightList { get; set; }

        public RadarViewModel(Grid inMotion)
        {
            movesList = new List<MovementModel>();
            viewCanvas = new Canvas();
            curentView = CoreApplication.GetCurrentView();
            stationImages = new List<StationToViewModel>();
            flightImages = new List<FlightToViewModel>();
            StationsList = new List<StationModel>();
            FlightList = new ObservableCollection<FlightModel>();
            GetDataToShow();
            SignalR();
            GenerateBoard(inMotion);
        }

        #region Test
        private void CreatFakeDataBase()
        {
            StationsList = new List<StationModel>();
            StationModel station1 = new StationModel
            {
                Strip = StripEnum.LandingStrip,
                IsDepartureEnd = false,
                IsDepartureStart = false,
                IsLandingEnd = false,
                IsLandingStart = true,
                Id = 1
            };
            StationModel station2 = new StationModel
            {
                Strip = StripEnum.LandingStrip,
                IsDepartureEnd = false,
                IsDepartureStart = false,
                IsLandingEnd = false,
                IsLandingStart = false,
                Id = 2
            };
            StationModel station3 = new StationModel
            {
                Strip = StripEnum.LandingStrip,
                IsDepartureEnd = false,
                IsDepartureStart = false,
                IsLandingEnd = false,
                IsLandingStart = false,
                Id = 3
            };
            StationModel station4 = new StationModel
            {
                Strip = StripEnum.AirLandingStrip,
                IsDepartureEnd = true,
                IsDepartureStart = false,
                IsLandingEnd = false,
                IsLandingStart = false,
                Id = 4
            };
            StationModel station5 = new StationModel
            {
                Strip = StripEnum.LandingStrip,
                IsDepartureEnd = false,
                IsDepartureStart = false,
                IsLandingEnd = false,
                IsLandingStart = false,
                Id = 5
            };
            StationModel station6 = new StationModel
            {
                Strip = StripEnum.AirLandingStrip,
                IsDepartureEnd = false,
                IsDepartureStart = true,
                IsLandingEnd = true,
                IsLandingStart = false,
                Id = 6
            };
            StationModel station7 = new StationModel
            {
                Strip = StripEnum.AirLandingStrip,
                IsDepartureEnd = false,
                IsDepartureStart = true,
                IsLandingEnd = true,
                IsLandingStart = false,
                Id = 7
            };
            StationModel station8 = new StationModel
            {
                Strip = StripEnum.AirStrip,
                IsDepartureEnd = false,
                IsDepartureStart = false,
                IsLandingEnd = false,
                IsLandingStart = false,
                Id = 8
            };
            station1.NextLandingStations.Add(station2);
            station2.NextLandingStations.Add(station3);
            station3.NextLandingStations.Add(station4);
            station4.NextLandingStations.Add(station5);
            station5.NextLandingStations.Add(station6);
            station5.NextLandingStations.Add(station7);
            station6.NextDepartureStations.Add(station8);
            station7.NextDepartureStations.Add(station8);
            station8.NextDepartureStations.Add(station4);
            StationsList.Add(station1);
            StationsList.Add(station2);
            StationsList.Add(station3);
            StationsList.Add(station4);
            StationsList.Add(station5);
            StationsList.Add(station6);
            StationsList.Add(station7);
            StationsList.Add(station8);
            //FlightList = new List<FlightModel>();
            FlightList.Add(new FlightModel()
            {
                FlightName = "AVI",
                ID = 1,
                IsDeparture = true,
                Time = DateTime.Now,
                IsFinish = false
            });
            FlightList.Add(new FlightModel()
            {
                FlightName = "Eli",
                ID = 2,
                IsDeparture = false,
                Time = DateTime.Now,
                IsFinish = false
            });
            station1.IsOccupied = true;
            station2.IsOccupied = true;
            station1.Flight = FlightList[0];
            station2.Flight = FlightList[1];
        }

        private FlightModel fakeLandFlight = new FlightModel()
        {
            FlightName = "Eli",
            ID = 2,
            IsDeparture = false,
            Time = DateTime.Now,
            IsFinish = false
        };
        private FlightModel fakeDepartureFlight = new FlightModel()
        {
            FlightName = "AVI",
            ID = 1,
            IsDeparture = true,
            Time = DateTime.Now,
            IsFinish = false
        };
        private int senarioStepLand = 0;
        private int senarioStepDepart = 0;
        public void PPressed()
        {
            switch (senarioStepDepart)
            {
                case 0:
                    {
                        AddMovementToList(fakeDepartureFlight, null);
                        senarioStepDepart++;
                        break;
                    }
                case 1:
                    {
                        AddMovementToList(fakeDepartureFlight, 6);
                        senarioStepDepart++;
                        break;
                    }
                case 2:
                    {
                        AddMovementToList(fakeDepartureFlight, 8);
                        senarioStepDepart++;
                        break;
                    }
                case 3:
                    {
                        AddMovementToList(fakeDepartureFlight, 4);
                        senarioStepDepart++;
                        break;
                    }
                case 4:
                    {
                        fakeDepartureFlight.IsFinish = true;
                        AddMovementToList(fakeDepartureFlight, null);
                        senarioStepDepart++;
                        break;
                    }
                case 5:
                    {
                        fakeDepartureFlight.IsFinish = false;
                        senarioStepDepart = 1;
                        AddMovementToList(fakeDepartureFlight, null);
                        break;
                    }
            }
        }
        public void Qpressed()
        {
            switch (senarioStepLand)
            {
                case 0:
                    {
                        AddMovementToList(fakeLandFlight, null);
                        senarioStepLand++;
                        break;
                    }
                case 1:
                    {
                        AddMovementToList(fakeLandFlight, 1);
                        senarioStepLand++;
                        break;
                    }
                case 2:
                    {
                        AddMovementToList(fakeLandFlight, 2);
                        senarioStepLand++;
                        break;
                    }
                case 3:
                    {
                        AddMovementToList(fakeLandFlight, 3);
                        senarioStepLand++;
                        break;
                    }
                case 4:
                    {
                        AddMovementToList(fakeLandFlight, 4);
                        senarioStepLand++;
                        break;
                    }
                case 5:
                    {
                        AddMovementToList(fakeLandFlight, 5);
                        senarioStepLand++;
                        break;
                    }
                case 6:
                    {
                        AddMovementToList(fakeLandFlight, 6);
                        senarioStepLand++;
                        break;
                    }
                case 7:
                    {
                        fakeLandFlight.IsFinish = true;
                        AddMovementToList(fakeLandFlight, null);
                        senarioStepLand++;
                        break;
                    }
                case 8:
                    {
                        fakeDepartureFlight.IsFinish = false;
                        senarioStepLand = 1;
                        AddMovementToList(fakeLandFlight, null);
                        break;
                    }
            }
        }
        #endregion

        #region Conection
        private void SignalR()
        {
            hubConnection = new HubConnection("http://localhost:53028/");
            hubProxy = hubConnection.CreateHubProxy("FlightsHub");
            hubConnection.Start();
            RegisterToHubCalls();
        }

        private void RegisterToHubCalls()
        {
            hubProxy.On<FlightDto>("FlightMove", flightDto =>
            {
                FlightModel flight = flightDto.ConvertToFlightModel();
                AddMovementToList(flight, flightDto.StationId);
                //MakeMove(flight, flightDto.StationId);
            });
        }

        private void GetDataToShow()
        {
            IEnumerable<FlightDto> FlightDtos = new List<FlightDto>();
            IEnumerable<StationDto> StationDtos = new List<StationDto>();
            string getStationsUrl = apiUrl + "/Stations";
            HttpResponseMessage responseMessage = client.GetAsync(getStationsUrl).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                StationDtos = responseMessage.Content.ReadAsAsync<IEnumerable<StationDto>>().Result;
            }
            StationsList = StationDtos.Select(s => s.ConvertToStationModel()).ToList();
            responseMessage = client.GetAsync(apiUrl).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                FlightDtos = responseMessage.Content.ReadAsAsync<IEnumerable<FlightDto>>().Result;
            }
            foreach (var flightDto in FlightDtos)
            {
                lock (lockObj)
                {
                    FlightList.Add(flightDto.ConvertToFlightModel());
                }
            }
        }

        private string MakeHttpGet(string controlerName)
        {
            var respons = client.GetAsync(apiUrl + controlerName).Result;
            return respons.Content.ReadAsStringAsync().Result;
        }
        #endregion

        #region view generate
        private void GenerateBoard(Grid inMotion)
        {
            horizontalCells = LongestPath() * 2;
            verticalCells = MaxStartStation() * 2;
            stationSize = 70;
            plainSize = 40;
            FillCanvas(CreatCanvasForView(inMotion));
        }
        private Canvas CreatCanvasForView(Grid inMotion)
        {
            viewCanvas.Width = inMotion.Width;
            viewCanvas.Height = inMotion.Height;
            inMotion.Children.Add(viewCanvas);
            return viewCanvas;
        }
        private void FillCanvas(Canvas viewCanvas)
        {
            #region station create
            stationImages.Add(new StationToViewModel() { stationPic = CreateStation(650, 100), Id = 1 });
            stationImages.Add(new StationToViewModel() { stationPic = CreateStation(500, 100), Id = 2 });
            stationImages.Add(new StationToViewModel() { stationPic = CreateStation(350, 100), Id = 3 });
            stationImages.Add(new StationToViewModel() { stationPic = CreateStation(200, 100), Id = 4 });
            stationImages.Add(new StationToViewModel() { stationPic = CreateStation(200, 250), Id = 5 });
            stationImages.Add(new StationToViewModel() { stationPic = CreateStation(200, 400), Id = 6 });
            stationImages.Add(new StationToViewModel() { stationPic = CreateStation(350, 400), Id = 7 });
            stationImages.Add(new StationToViewModel() { stationPic = CreateStation(350, 250), Id = 8 });
            stationImages.Add(new StationToViewModel() { stationPic = CreateStation(50, 400), Id = 9 });

            #endregion

            foreach (StationToViewModel image in stationImages)
            {
                viewCanvas.Children.Add(image.stationPic);
            }  // add station image tob canvas

            for (int i = 0; i < StationsList.Count; i++)
            {
                if (StationsList[i].IsOccupied)
                {
                    Image plainImage = CreatePlain((Double)stationImages[i].stationPic.GetValue(Canvas.LeftProperty),
                                                  (Double)stationImages[i].stationPic.GetValue(Canvas.TopProperty),
                                                   StationsList[i].Flight.IsDeparture,
                                                   StationsList[i].Flight.FlightName);
                    FlightToViewModel plainView = new FlightToViewModel() { Id = StationsList[i].Flight.ID, FlightPic = plainImage };
                    flightImages.Add(plainView);
                    viewCanvas.Children.Add(plainImage);

                }
            }   // add plain image to station that oqupy

            #region path creat
            viewCanvas.Children.Add(CreatPaths(true, 650 + stationSize, 100 + stationSize / 2, 140 - stationSize));
            viewCanvas.Children.Add(CreatPaths(true, 650 + stationSize, 100 + stationSize / 2, 10, 10));
            viewCanvas.Children.Add(CreatPaths(true, 650 + stationSize, 100 + stationSize / 2, 10, -10));
            viewCanvas.Children.Add(CreatPaths(true, 500 + stationSize, 100 + stationSize / 2, 140 - stationSize));
            viewCanvas.Children.Add(CreatPaths(true, 500 + stationSize, 100 + stationSize / 2, 10, 10));
            viewCanvas.Children.Add(CreatPaths(true, 500 + stationSize, 100 + stationSize / 2, 10, -10));
            viewCanvas.Children.Add(CreatPaths(true, 350 + stationSize, 100 + stationSize / 2, 140 - stationSize));
            viewCanvas.Children.Add(CreatPaths(true, 350 + stationSize, 100 + stationSize / 2, 10, 10));
            viewCanvas.Children.Add(CreatPaths(true, 350 + stationSize, 100 + stationSize / 2, 10, -10));
            viewCanvas.Children.Add(CreatPaths(true, 200 + stationSize, 100 + stationSize / 2, 140 - stationSize));
            viewCanvas.Children.Add(CreatPaths(true, 200 + stationSize, 100 + stationSize / 2, 10, 10));
            viewCanvas.Children.Add(CreatPaths(true, 200 + stationSize, 100 + stationSize / 2, 10, -10));
            viewCanvas.Children.Add(CreatPaths(true, 200 + stationSize / 2, 100 + stationSize, 0, 140 - stationSize));
            viewCanvas.Children.Add(CreatPaths(true, 200 + stationSize / 2, 240, 10, -10));
            viewCanvas.Children.Add(CreatPaths(true, 200 + stationSize / 2, 240, -10, -10));
            viewCanvas.Children.Add(CreatPaths(true, 200 + stationSize / 2, 250 + stationSize, 0, 140 - stationSize));
            viewCanvas.Children.Add(CreatPaths(true, 200 + stationSize / 2, 390, 10, -10));
            viewCanvas.Children.Add(CreatPaths(true, 200 + stationSize / 2, 390, -10, -10));
            viewCanvas.Children.Add(CreatPaths(true, 200 + stationSize / 2, 250 + stationSize, 140, 140 - stationSize));
            viewCanvas.Children.Add(CreatPaths(true, 340 + stationSize / 2, 390, 0, -10));
            viewCanvas.Children.Add(CreatPaths(true, 340 + stationSize / 2, 390, -10, 0));
            viewCanvas.Children.Add(CreatPaths(true, 200 + stationSize / 2, 400 + stationSize, 0, 140 - stationSize));
            viewCanvas.Children.Add(CreatPaths(true, 200 + stationSize / 2, 540, 10, -10));
            viewCanvas.Children.Add(CreatPaths(true, 200 + stationSize / 2, 540, -10, -10));
            viewCanvas.Children.Add(CreatPaths(true, 350 + stationSize / 2, 400 + stationSize, 0, 140 - stationSize));
            viewCanvas.Children.Add(CreatPaths(true, 350 + stationSize / 2, 540, 10, -10));
            viewCanvas.Children.Add(CreatPaths(true, 350 + stationSize / 2, 540, -10, -10));

            viewCanvas.Children.Add(CreatPaths(false, 210 + stationSize / 2, 410 + stationSize, stationSize - 10, 140 - stationSize));
            viewCanvas.Children.Add(CreatPaths(false, 210 + stationSize / 2, 410 + stationSize, 10, 0));
            viewCanvas.Children.Add(CreatPaths(false, 210 + stationSize / 2, 410 + stationSize, 0, 10));

            viewCanvas.Children.Add(CreatPaths(false, 340 + stationSize / 2, 410 + stationSize, -stationSize + 10, 140 - stationSize));
            viewCanvas.Children.Add(CreatPaths(false, 340 + stationSize / 2, 410 + stationSize, -10, 0));
            viewCanvas.Children.Add(CreatPaths(false, 340 + stationSize / 2, 410 + stationSize, 0, 10));

            viewCanvas.Children.Add(CreatPaths(false, 200 + stationSize / 2, 400, 140, stationSize - 140));
            viewCanvas.Children.Add(CreatPaths(false, 340 + stationSize / 2, 260 + stationSize, 0, 10));
            viewCanvas.Children.Add(CreatPaths(false, 340 + stationSize / 2, 260 + stationSize, -10, 0));

            viewCanvas.Children.Add(CreatPaths(false, 350 + stationSize / 2, 260 + stationSize, 0, 130 - stationSize));
            viewCanvas.Children.Add(CreatPaths(false, 350 + stationSize / 2, 260 + stationSize, 10, 10));
            viewCanvas.Children.Add(CreatPaths(false, 350 + stationSize / 2, 260 + stationSize, -10, 10));


            viewCanvas.Children.Add(CreatPaths(false, 210 + stationSize / 2, 110 + stationSize, 150, 130 - stationSize));
            viewCanvas.Children.Add(CreatPaths(false, 210 + stationSize / 2, 110 + stationSize, 0, 10));
            viewCanvas.Children.Add(CreatPaths(false, 210 + stationSize / 2, 110 + stationSize, 10, 0));

            viewCanvas.Children.Add(CreatPaths(false, 50 + stationSize, 100 + stationSize / 2, 150 - stationSize));
            viewCanvas.Children.Add(CreatPaths(false, 50 + stationSize, 100 + stationSize / 2, 10, 10));
            viewCanvas.Children.Add(CreatPaths(false, 50 + stationSize, 100 + stationSize / 2, 10, -10));
            #endregion
        }
        private Image CreateStation(int left, int top)
        {
            BitmapImage img = new BitmapImage { UriSource = new Uri("ms-appx:///Assets/Station.png") };
            Image temp = new Image()
            {
                Name = "S1",
                Source = img,
                Width = stationSize,
            };
            temp.SetValue(Canvas.LeftProperty, left);
            temp.SetValue(Canvas.TopProperty, top);
            return temp;
        }
        private Image CreatePlain(Double left, Double top, bool isDiparture, string name)
        {
            Image temp = null;
            BitmapImage img = new BitmapImage();
            if (isDiparture)
                img.UriSource = new Uri("ms-appx:///Assets/DeparturePlain.png");
            else
                img.UriSource = new Uri("ms-appx:///Assets/ArivePlain.png");
            temp = new Image()
            {
                Name = name,
                Source = img,
                Width = plainSize,
            };
            temp.SetValue(Canvas.LeftProperty, left + stationSize * .2);
            temp.SetValue(Canvas.TopProperty, top + stationSize * .6);
            return temp;
        }
        private Line CreatPaths(bool IsGreen, int left, int top, int width = 0, int hight = 0)
        {
            Line temp = new Line();
            if (IsGreen)
                temp.Stroke = new SolidColorBrush(Colors.Green);
            else
                temp.Stroke = new SolidColorBrush(Colors.Red);
            temp.SetValue(Canvas.LeftProperty, left);
            temp.SetValue(Canvas.TopProperty, top);
            temp.X1 = width;
            temp.Y1 = hight;
            return temp;
        }

        #endregion

        #region Move The Flights
        private void MakeMove(FlightModel flight, int? stationId)
        {
            if (stationId == null && !flight.IsFinish)
            {
                curentView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                          () =>
                          {
                              lock (lockObj)
                              {
                                  FlightList.Add(flight);
                              }
                          });
                MakeMove();
            }
            else
            {
                MakeMoveIfFlightNotNew(flight, stationId);
            }
        }
        private void MakeMoveIfFlightNotNew(FlightModel flight, int? stationId)
        {
            Task move;
            if (flight.IsFinish)
            {
                move = new Task(() => MakeMoveFromLastBase(flight, stationId));// .continumewhite(removeformView);
            }
            else if (IsBaseStation(flight, (int)stationId))
            {
                move = new Task(() => MakeMoveToFirstBase(flight, stationId));
            }
            else // throu the path
            {
                move = new Task(() => MakeMoveBetwinStations(flight, stationId));
            }
            move.Start();
            move.Wait();
            MakeMove();
        }
        private Task MakeMoveFromLastBase(FlightModel flight, int? stationId)
        {
            StationModel flightOldStation = StationsList.FirstOrDefault(s =>
            {
                {
                    return s.Flight != null && s.Flight.ID == flight.ID;
                }
            });
            FlightModel flightToMove = flightOldStation.Flight;
            Image plainToFly = GetPlainImage(flightOldStation);
            RemoveFlightFromStation(flightToMove, flightOldStation);
            return MoveOutFromStations(plainToFly, flightOldStation);
        }
        private Task MakeMoveToFirstBase(FlightModel flight, int? stationId)
        {
            curentView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                      () =>
                      {
                          FlightModel flightToMove = null;
                          foreach (var flightPivot in FlightList)
                          {
                              if (flightPivot.ID == flight.ID)
                                  flightToMove = flightPivot;
                          }
                          StationModel flightNewStation = StationsList.Find(s => s.Id == stationId);
                          FlightList.Remove(flightToMove);
                          PutFilghtInStation(flightToMove, flightNewStation);
                          Image newFlight = new Image();
                          if (flightNewStation.Id == 1)
                              newFlight = CreatePlain(750, 100, flightToMove.IsDeparture, flightToMove.FlightName);
                          else
                              newFlight = CreatePlain(275, 500, flightToMove.IsDeparture, flightToMove.FlightName);
                          flightImages.Add(new FlightToViewModel { Id = flight.ID, FlightPic = newFlight });
                          viewCanvas.Children.Add(newFlight);
                          MoveInToStations(newFlight, flightNewStation);
                      });
            return Task.CompletedTask;


        }
        private Task MakeMoveBetwinStations(FlightModel flight, int? stationId)
        {
            return curentView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                         () =>
                         {
                             StationModel flightNewStation = StationsList.Find(s => s.Id == stationId);
                             StationModel flightOldStation = StationsList.FirstOrDefault(s =>
                             {
                                 {
                                     return s.Flight != null && s.Flight.ID == flight.ID;
                                 }
                             });
                             FlightModel flightToMove = flightOldStation.Flight;
                             Image plainToFly = GetPlainImage(flightOldStation);
                             RemoveFlightFromStation(flightToMove, flightOldStation);
                             PutFilghtInStation(flightToMove, flightNewStation);
                             MoveInToStations(plainToFly, flightNewStation);
                         }).AsTask();
        }
        private bool IsBaseStation(FlightModel flight, int stationId)
        {
            bool flag = false;
            foreach (StationModel station in StationsList)
            {
                if ((station.Id == stationId) &&
                           ((station.IsDepartureStart == true) && (flight.IsDeparture) ||
                           (station.IsLandingStart == true) && !(flight.IsDeparture)))
                    flag = true;
            }
            return flag;
        }
        private void PutFilghtInStation(FlightModel flight, StationModel station)
        {
            station.Flight = flight;
            station.FlightId = flight.ID;
        }
        private void RemoveFlightFromStation(FlightModel flight, StationModel Station)
        {
            Station.Flight = null;
            Station.FlightId = null;
        }
        private Image GetPlainImage(StationModel flightOldStation)
        {
            return flightImages.FirstOrDefault(f => f.Id == flightOldStation.Flight.ID).FlightPic;
        }
        private Task MoveOutFromStations(Image plainFlight, StationModel oldStation)
        {
            double x, y;
            if (oldStation.Id == 4)
            {
                x = 1;
                y = 100 + stationSize * .6;
            }
            else
            {
                x = 275;
                y = 500;
            }
            return MakeTheMove(plainFlight, x, y).ContinueWith((a) =>
              curentView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                          () =>
                          {
                              Thread.Sleep(1000);
                              viewCanvas.Children.Remove(plainFlight);
                          }));
        }
        private async void MoveInToStations(Image plainFlight, StationModel newStation)
        {
            Image nextStation = stationImages.FirstOrDefault(s => s.Id == newStation.Id).stationPic;
            double x = ((double)nextStation.GetValue(Canvas.LeftProperty)) + (stationSize * .2);
            double y = ((double)nextStation.GetValue(Canvas.TopProperty)) + (stationSize * .6);
            await MakeTheMove(plainFlight, x, y);
        }
        private async Task MakeTheMove(Image plainFlight, double x, double y)
        {
            await curentView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                          () =>
                          {
                              Duration Duration = new Duration(TimeSpan.FromSeconds(2));
                              DoubleAnimation xAnimation = new DoubleAnimation();
                              DoubleAnimation yAnimation = new DoubleAnimation();
                              xAnimation.Duration = Duration;
                              yAnimation.Duration = Duration;
                              Storyboard sb = new Storyboard();
                              //sb.Duration = Duration;
                              sb.Children.Add(xAnimation);
                              sb.Children.Add(yAnimation);
                              Storyboard.SetTarget(xAnimation, plainFlight);
                              Storyboard.SetTarget(yAnimation, plainFlight);
                              Storyboard.SetTargetProperty(xAnimation, "(Canvas.Left)");
                              Storyboard.SetTargetProperty(yAnimation, "(Canvas.Top)");
                              xAnimation.To = x;
                              yAnimation.To = y;
                              sb.Begin();
                          });
        }
        #endregion

        #region Calculate View CEll Sizes
        private int LongestPath()
        {
            int maxStationPath = 0;
            foreach (var station in StationsList)
            {
                if (station.IsLandingStart || station.IsDepartureStart)
                {
                    int temp = GetPathSize(station);
                    if (maxStationPath < temp)
                        maxStationPath = temp;
                }
            }
            return maxStationPath;
        }
        private int GetPathSize(StationModel station)
        {
            if (station.IsDepartureStart)
            {
                return GetMaxDeparturePathSize(station);
            }
            else
            {
                return GetMaxArivalPathSize(station);
            }
        }
        private int GetMaxArivalPathSize(StationModel station)
        {
            if (station.NextLandingStations.Count == 0)
                return 1;
            else
            {
                int counter = 0;
                foreach (var nextStation in station.NextLandingStations)
                {
                    int temp = GetMaxArivalPathSize(nextStation);
                    if (temp > counter)
                        counter = temp;
                }
                return counter + 1;
            }
        }
        private int GetMaxDeparturePathSize(StationModel station)
        {
            if (station.NextDepartureStations.Count == 0)
                return 1;
            else
            {
                int counter = 0;
                foreach (var nextStation in station.NextDepartureStations)
                {
                    int temp = GetMaxDeparturePathSize(nextStation);
                    if (temp > counter)
                        counter = temp;
                }
                return counter + 1;
            }
        }
        private int MaxStartStation()
        {
            int lastLend = 0, startLend = 0;
            int lastDepart = 0, startDepart = 0;
            foreach (var station in StationsList)
            {
                if (station.IsDepartureEnd)
                {
                    lastDepart++;
                }
                else if (station.IsDepartureStart)
                {
                    startDepart++;
                }
                else if (station.IsLandingEnd)
                {
                    lastLend++;
                }
                else if (station.IsLandingStart)
                {
                    startLend++;
                }
            }
            return Math.Max(Math.Max(startDepart, startLend), Math.Max(lastDepart, lastLend));
        }
        #endregion

        private void AddMovementToList(FlightModel flight, int? stationId)
        {
            movesList.Add(new MovementModel { Flight = flight, StationId = stationId });
            if (!inAction)
            {
                inAction = true;
                MakeMove();
            }
        }

        private void MakeMove()
        {
            if (movesList.Count > 0)
            {
                MovementModel nextMove = movesList[0];
                movesList.Remove(nextMove);
                MakeMove(nextMove.Flight, nextMove.StationId);
            }
            else
                inAction = false;
        }
    }
}
