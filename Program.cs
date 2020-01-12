//실행은 안되는데 세이브용으로 올려둠
using System;

namespace 간단한게임
{
	class Program
	{
		static int playerPoint = 0;
		static int TargetPoint = 1;
		static int[,] objects = new int[836,2];
		static int[,] c = new int[836,2];
		public static void Main(string[] args)
		{
			int score = 0;
			int MovableTimes = 61;
			ConsoleKeyInfo input;
			objects[0,0] = 5;
			objects[0,1] = 5;
			objects[1,0] = 10;
			objects[1,1] = 10;
			first:
			Console.Clear();
			drawing(objects);
			MovableTimes--;
			
			if(MovableTimes <= 0){
				goto end;
			}
			Console.WriteLine("점수 : " + score + "  이동가능한 횟수 : " + MovableTimes);
			
			input = Console.ReadKey(true);
			if(input.Key == ConsoleKey.UpArrow && objects[0,1] != 0) objects[0,1]--;
			else if(input.Key == ConsoleKey.DownArrow && objects[0,1] < 23) objects[0,1]++; 
			if(input.Key == ConsoleKey.LeftArrow && objects[0,2] != 0) objects[0,2]--;      
			else if(input.Key == ConsoleKey.RightArrow && objects[0,2] < 38) objects[0,2]++;
			goto first;
			
		end:
			Console.WriteLine("게임 오버");
			while(true){
				Console.ReadKey();
			}
		}
		
		public static void drawing(int[,] input){
			sequential(input);
			input = c;
			for(int a = 0; a < input.GetLength(0); a++){
				for(int b = 0; b < input.GetLength(1); b++){
					Console.Write(input[a,b]);
				}
				Console.Write("\n");
			}
			Console.ReadKey();
			for(int a = 0; a < input.Length; a++){
				int x = input[a,0];
				int y = input[a,1];
				try{
					if(input[a-1,1] != input[a,1]){
						for(int b = 0; b < input.Length; b++){
							Console.Write("\n");
						}
						for(int b = 0; b < input.Length; b++){
							Console.Write("  ");
						}
						if(a == playerPoint){
							Console.Write("■");
						}
						else if(a == TargetPoint){
							Console.Write("□");
						}
					}
				}
				catch{
					for(int b = 0; b < 5; b++){
							Console.Write("\n");
						}
						for(int b = 0; b < input[a,0]; b++){
							Console.Write("  ");
						}
						if(a == playerPoint){
							Console.Write("■");
						}
						else if(a == TargetPoint){
							Console.Write("□");
						}
					}
				}
		}
		
		public static void sequential(int[,] input){
			for(int a = 0; a < 836; a++){
				c[a,1] = 10000;
				try{
					for(int b = 0; b < 836; b++){
						if(c[a,1] > input[b,1] && c[a-1,1] < input[b,1]){
							if(b == playerPoint){
								playerPoint = a;
							}
							else if(b == TargetPoint){
								TargetPoint = a;
							}
							c[a,1] = input[b,1];
						}
						//else if(c[a,1] == input[b,1] && c[a-1,1] < input[b,1]){
						//	if(b = playerPoint){
						//		playerPoint = a;
						//	}
						//	else if(b = TargetPoint){
						//		TargetPoint = a;
						//	}
						//	c[a,1] = input[b,1];
						//}
					}
				}
				catch{
					for(int b = 0; b < 836; b++){
						if(c[a,1] > input[b,1]){
							if(b == playerPoint){
								playerPoint = a;
							}
							else if(b == TargetPoint){
								TargetPoint = a;
							}
							c[a,1] = input[b,1];
						}
						//else if(c[a,1] == input[b,1]){
						//	if(b = playerPoint){
						//		playerPoint = a;
						//	}
						//	else if(b = TargetPoint){
						//		TargetPoint = a;
						//	}
						//	c[a,1] = input[b,1];
						//}
					}
				}
			}
		}
	}
}
