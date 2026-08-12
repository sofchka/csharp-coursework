using sol3;

Elevator elevator = new Elevator();

elevator.MakeRequest(80);
elevator.MakeRequest(90);
elevator.MakeRequest(20);
elevator.Start();
elevator.MakeRequest(5);
elevator.MakeRequest(8);
elevator.MakeRequest(9);
elevator.MakeRequest(2);
