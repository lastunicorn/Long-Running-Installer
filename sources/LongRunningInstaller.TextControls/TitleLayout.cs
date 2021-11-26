// LongRunningInstaller
// Copyright (C) 2021 Dust in the Wind
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;

namespace DustInTheWind.LongRunningInstaller.TextControls
{
    internal class TitleLayout
    {
        public int Width { get; }

        public int LeftThinFeatherLength { get; }

        public int LeftThickFeatherLength { get; }

        public int RightThinFeatherLength { get; }

        public int RightThickFeatherLength { get; }

        public TitleLayout(Title title)
        {
            int titleTextWidth = title.Text?.Length ?? 0;
            int titleBoxWidth = titleTextWidth + 4;
            int neededWidth = titleBoxWidth + 2 * title.MinWingLength;

            int actualWidth = Math.Max(title.MinWidth, neededWidth);

            int wingsSpace = actualWidth - titleBoxWidth;
            bool isWingsSpaceEven = wingsSpace % 2 == 0;

            if (isWingsSpaceEven)
            {
                int actualLeftWingLength = wingsSpace / 2;
                int actualRightWingLength = actualLeftWingLength;

                LeftThickFeatherLength = actualLeftWingLength * title.ThickFeatherPercentage / 100;
                LeftThinFeatherLength = actualLeftWingLength - LeftThickFeatherLength;

                RightThickFeatherLength = actualRightWingLength * title.ThickFeatherPercentage / 100;
                RightThinFeatherLength = actualRightWingLength - LeftThickFeatherLength;
            }
            else
            {
                int actualLeftWingLength = (wingsSpace - 1) / 2;
                int actualRightWingLength = actualLeftWingLength + 1;

                LeftThickFeatherLength = actualLeftWingLength * title.ThickFeatherPercentage / 100;
                LeftThinFeatherLength = actualLeftWingLength - LeftThickFeatherLength;

                RightThickFeatherLength = actualRightWingLength * title.ThickFeatherPercentage / 100;
                RightThinFeatherLength = actualRightWingLength - RightThickFeatherLength;
            }

            Width = actualWidth;
        }
    }
}