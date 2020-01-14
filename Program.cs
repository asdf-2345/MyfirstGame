using System;

namespace 간단한게임
{
	class Program
	{
		static int[,] objects = new int[100,2];
		static int score = 0;
		static int MovableTimes = 61;
		static int[] playerOldPosition = new int[2];
		
		public static void start(){
      		objects[0,0] = 5;
      		objects[0,1] = 5;
      		objects[1,0] = 10;
      		objects[1,1] = 10;
      		objects[2,0] = 10;
      		objects[2,1] = 9;
      		objects[3,0] = 9;
      		objects[3,1] = 9;
      		objects[4,0] = 9;
      		objects[4,1] = 10;
      		objects[5,0] = 9;
      		objects[5,1] = 11;
      		objects[6,0] = 10;
      		objects[6,1] = 11;
      		objects[7,0] = 11;
      		objects[7,1] = 11;
      		objects[8,0] = 11;
      		objects[8,1] = 9;
	    	//0은 플레이어 1은 목표 2이상은 장애물
	    	drawing2();
	    }

		public static void Main(string[] args)
		{
			start();
			ConsoleKeyInfo input;
			first:
			drawing();
			MovableTimes--;
			if(MovableTimes <= 0){
				goto end;
			}
			Console.WriteLine("                                                             ");
			Console.SetCursorPosition(0,0);
			Console.Write("점수 : " + score + "  이동가능한 횟수 : " + MovableTimes);
			playerOldPosition[0] = objects[0,0];
			playerOldPosition[1] = objects[0,1];
			
			input = Console.ReadKey(true);
			if(input.Key == ConsoleKey.UpArrow && objects[0,1] != 0) objects[0,1]--;
			else if(input.Key == ConsoleKey.DownArrow && objects[0,1] < 23) objects[0,1]++; 
			if(input.Key == ConsoleKey.LeftArrow && objects[0,0] != 0) objects[0,0]--;      
			else if(input.Key == ConsoleKey.RightArrow && objects[0,0] < 38) objects[0,0]++;
			goto first;
			
		end:
			Console.Clear();
			Console.SetCursorPosition(35,12);
			Console.WriteLine("게임 오버");
			while(true){
				Console.ReadKey();
			}
		}
		
		public static void drawing(){
			if(objects[0,0] == objects[1,0] && objects[0,1] == objects[1,1])
				achieveTheGoal();
			for(int a = 2; a < objects.GetLength(0); a++){//장애물 충돌판정
				if(objects[0,0] == objects[a,0] && objects[0,1] == objects[a,1]){
					objects[0,0] = playerOldPosition[0];
					objects[0,1] = playerOldPosition[1];
					break;
				}
			}
			Console.SetCursorPosition(playerOldPosition[0]*2+1, playerOldPosition[1]+1);
			Console.WriteLine("\b \b");
			
			Console.SetCursorPosition(objects[0,0]*2, objects[0,1]+1);
			Console.Write("■");
			
			Console.SetCursorPosition(0,0);
		}
		
		public static void achieveTheGoal(){
			score++;
			MovableTimes += 20;
			Random ran = new Random();
			objects[1,0] = ran.Next(3, 38);
			objects[1,1] = ran.Next(3, 23);
			for(int a = 2; a < 60; a++){
				randomSetAgain:
				objects[a,0] = ran.Next(0, 38);
				objects[a,1] = ran.Next(0, 23);
				if((objects[0,0] == objects[a,0] && objects[0,1] == objects[a,1]) || (objects[1,0] == objects[a,0] && objects[0,1] == objects[a,1]))
					goto randomSetAgain;
			}
			drawing2();
		}
		
		public static void drawing2(){
			Console.Clear();
			for(int a = 2; a < objects.GetLength(0); a++){
				Console.SetCursorPosition(objects[a,0]*2, objects[a,1]+1);
				Console.Write("☆");
			}
			Console.SetCursorPosition(objects[1,0]*2, objects[1,1]+1);
			Console.Write("□");
		}
	}
}
