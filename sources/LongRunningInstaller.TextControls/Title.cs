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

using System.Text;

namespace DustInTheWind.LongRunningInstaller.TextControls
{
    public class Title
    {
        public int MinWidth { get; set; } = 100;

        public int MinWingLength { get; set; } = 15;

        public Percentage ThickFeatherPercentage { get; set; } = 33;

        public string Text { get; set; }

        public Title(string text)
        {
            Text = text;
        }

        public override string ToString()
        {
            TitleLayout titleLayout = new TitleLayout(this);

            StringBuilder sb = new StringBuilder(titleLayout.Width);

            sb.Append(new string('-', titleLayout.LeftThinFeatherLength));
            sb.Append(new string('=', titleLayout.LeftThickFeatherLength));
            sb.Append($"{{ {Text} }}");
            sb.Append(new string('=', titleLayout.RightThickFeatherLength));
            sb.Append(new string('-', titleLayout.RightThinFeatherLength));

            return sb.ToString();
        }

        public static implicit operator string(Title title)
        {
            return title.ToString();
        }
    }
}