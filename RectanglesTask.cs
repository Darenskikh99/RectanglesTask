using System;

namespace Rectangles
{
	public static class RectanglesTask
	{
		enum RecntangleHasRectangle
        {
			RectanglesNotMatch = -1,
			FirstRectangleInSecondRectangle,
			SecondRectangleInFirstRectangle
        }

		public static bool AreIntersected(Rectangle r1, Rectangle r2)
		{
			bool answer = false;
			if (horizontaltSideLiesOnSide(r1, r2))
			{
				if (verticaltSideLiesOnSide(r1, r2))
					answer = true;
				else if (verticaltSideLiesOnSide(r2, r1))
					answer = true;
			}
			else if (horizontaltSideLiesOnSide(r2, r1))
			{
				if (verticaltSideLiesOnSide(r1, r2))
					answer = true;
				else if (verticaltSideLiesOnSide(r2, r1))
					answer = true;
			}
			return answer;
		}

		// Площадь пересечения прямоугольников
		public static int IntersectionSquare(Rectangle r1, Rectangle r2)
        {
            int square = 0;
			square = calculateIntersectionSquare(r1, r2);
            return square;
        }


        // Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
        // Иначе вернуть -1
        // Если прямоугольники совпадают, можно вернуть номер любого из них.
        public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
		{
			int answer = -1;

			if (horizontaltSideLiesInSide(r1, r2) && verticaltSideLiesInSide(r1, r2))
				answer = (int)RecntangleHasRectangle.FirstRectangleInSecondRectangle;
			else if (horizontaltSideLiesInSide(r2, r1) && verticaltSideLiesInSide(r2, r1))
				answer = (int)RecntangleHasRectangle.SecondRectangleInFirstRectangle;
			else
				answer = (int)RecntangleHasRectangle.RectanglesNotMatch;

			return answer;
		}

		private static bool horizontaltSideLiesOnSide (Rectangle r1, Rectangle r2)
        {
			return r1.Left >= r2.Left && r1.Left <= r2.Left + r2.Width ||
				r1.Left + r1.Width >= r2.Left && r1.Left + r1.Width <= r2.Left + r2.Width;
        }

		private static bool verticaltSideLiesOnSide(Rectangle r1, Rectangle r2)
		{
			return r1.Top >= r2.Top && r1.Top <= r2.Top + r2.Height ||
				r1.Top + r1.Height >= r2.Top && r1.Top + r1.Height <= r2.Top + r2.Height;
		}

		private static bool horizontaltSideLiesInSide(Rectangle r1, Rectangle r2)
		{
			return r1.Left >= r2.Left && r1.Left + r1.Width <= r2.Left + r2.Width;
		}

		private static bool verticaltSideLiesInSide(Rectangle r1, Rectangle r2)
		{
			return r1.Top >= r2.Top && r1.Top + r1.Height <= r2.Top + r2.Height;
		}

        private static int calculateIntersectionSquare(Rectangle r1, Rectangle r2)
        {
            int square = 0;
			if(AreIntersected(r1, r2))
            {
				switch (IndexOfInnerRectangle(r1, r2))
                {
					case -1:
						square = squareINtersection(r1, r2);
						break;
					case 0:
						square = r1.Height * r1.Width;
						break;
					case 1:
						square = r2.Height * r2.Width;
						break;
				}
			}
            else square = 0;
            return square;
        }

		private static int squareINtersection(Rectangle r1, Rectangle r2)
        {
			int intersectionHeight = 0, intersectionWidth = 0;
			if (r1.Top >= r2.Top && r1.Top <= r2.Top + r2.Height)
			{
				if (r1.Top + r1.Height >= r2.Top && r1.Top + r1.Height <= r2.Top + r2.Height)
					intersectionHeight = r1.Height;
				else
					intersectionHeight = r2.Top + r2.Height - r1.Top;
			}
			else if (r1.Top + r1.Height > r2.Top + r2.Height)
				intersectionHeight = r2.Height;
			else intersectionHeight = r1.Top + r1.Height - r2.Top;
			if (r1.Left >= r2.Left && r1.Left <= r2.Left + r2.Width)
			{
				if (r1.Left + r1.Width >= r2.Left && r1.Left + r1.Width <= r2.Left + r2.Width)
					intersectionWidth = r1.Width;
				else
					intersectionWidth = r2.Left + r2.Width - r1.Left;
			}
			else if (r1.Left + r1.Width > r2.Left + r2.Width)
				intersectionWidth = r2.Width;
			else intersectionWidth = r1.Left + r1.Width - r2.Left;
			return intersectionWidth * intersectionHeight;
		}
	}
}