using System;

namespace 간단한게임
{
	class Program
	{
		public static void Main(string[] args)
		{
			int score = 0;
			int MovableTimes = 61;
			ConsoleKeyInfo input;
			int x1 = 0, x2 = 10, y1 = 0, y2 = 10;
			first:
			Console.Clear();
			MovableTimes--;
			if(MovableTimes <= 0){
				goto end;
			}
			Console.WriteLine("점수 : " + score + "  이동가능한 횟수 : " + MovableTimes);
			if(y1 < y2){
				for(int a = 0; a < y1; a++){
					Console.Write("\n");
				}
				for(int a = 0; a < x1; a++){
					Console.Write("  ");
				}
				Console.Write("■");
				
				for(int a = 0; a < (y2 - y1); a++){
					Console.Write("\n");
				}
				for(int a = 0; a < x2; a++){
					Console.Write("  ");
				}
				Console.Write("□");
			}
			else if(y1 > y2){
				for(int a = 0; a < y2; a++){
					Console.Write("\n");
				}
				for(int a = 0; a < x2; a++){
					Console.Write("  ");
				}
				Console.Write("□");
				
				for(int a = 0; a < (y1 - y2); a++){
					Console.Write("\n");
				}
				for(int a = 0; a < x1; a++){
					Console.Write("  ");
				}
				Console.Write("■");
			}
			else if(y1 == y2){
				if(x1 == x2){
					Random r = new Random();
					x2 = r.Next(0, 39);
					y2 = r.Next(0, 23);
					for(int a = 0; a < y1; a++){
						Console.Write("\n");
					}
					for(int a = 0; a < x1; a++){
						Console.Write("  ");
					}
					Console.Write("■");
					score++;
					MovableTimes = 60;
					goto first;
				}
				else{
					if(x1 > x2){
						for(int a = 0; a < y1; a++){
							Console.Write("\n");
						}
						for(int a = 0; a < x2; a++){
							Console.Write("  ");
						}
						Console.Write("□");
						for(int a = 0; a < (x1 - x2 - 1); a++){
							Console.Write("  ");
						}
						Console.Write("■");
					}
					if(x1 < x2){
						for(int a = 0; a < y1; a++){
							Console.Write("\n");
						}
						for(int a = 0; a < x1; a++){
							Console.Write("  ");
						}
						Console.Write("■");
						
						for(int a = 0; a < (x2 - x1 - 1); a++){
							Console.Write("  ");
						}
						Console.Write("□");
					}
				}
			}
			input = Console.ReadKey(true);
			if(input.Key == ConsoleKey.UpArrow && y1 != 0) y1--;
			else if(input.Key == ConsoleKey.DownArrow && y1 < 23) y1++; 
			if(input.Key == ConsoleKey.LeftArrow && x1 != 0) x1--;      
			else if(input.Key == ConsoleKey.RightArrow && x1 < 38) x1++;
			goto first;
			
		end:
			Console.WriteLine("게임 오버");
			while(true){
				Console.ReadKey();
			}
		}
	}
}
