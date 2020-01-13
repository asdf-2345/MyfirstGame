using System;

namespace 간단한게임
{
	class Program
	{
		static int[,] objects = new int[100,2];
		static int score = 0;
		static int MovableTimes = 61;
		public static void Main(string[] args)
		{
			ConsoleKeyInfo input;
			objects[0,0] = 5;
			objects[0,1] = 5;
			objects[1,0] = 10;
			objects[1,1] = 10;
			//0은 플레이어 1은 목표 2이상은 장애물
			first:
			Console.Clear();
			drawing();
			MovableTimes--;
			
			if(MovableTimes <= 0){
				goto end;
			}
			Console.WriteLine("점수 : " + score + "  이동가능한 횟수 : " + MovableTimes);
			
			input = Console.ReadKey(true);
			if(input.Key == ConsoleKey.UpArrow && objects[0,1] != 0) objects[0,1]--;
			else if(input.Key == ConsoleKey.DownArrow && objects[0,1] < 23) objects[0,1]++; 
			if(input.Key == ConsoleKey.LeftArrow && objects[0,0] != 0) objects[0,0]--;      
			else if(input.Key == ConsoleKey.RightArrow && objects[0,0] < 38) objects[0,0]++;
			goto first;
			
		end:
			Console.WriteLine("게임 오버");
			while(true){
				Console.ReadKey();
			}
		}
		
		public static void drawing(){
			if(objects[0,0] == objects[1,0] && objects[0,1] == objects[1,1]){
				score++;
				MovableTimes = 61;
				Random ran = new Random();
				objects[1,0] = ran.Next(0, 39);
				objects[1,1] = ran.Next(0, 23);
			}
			for(int a = 0; a < objects.GetLength(0); a++){
				Console.SetCursorPosition(objects[a,0]*2, objects[a,1]+1);
				if(a == 0){
					Console.Write("■");
				}
				else if(a == 1){
					Console.Write("□");
				}
				else{
					Console.Write("◇");
				}		
			}
			Console.SetCursorPosition(0,0);
		}
	}
}
