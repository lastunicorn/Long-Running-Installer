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
using System.IO;

namespace LongRunningInstaller.Sleepy.UseCase
{
    internal class StopFlag
    {
        private readonly string stopFilePath;

        public bool IsStopRequested => File.Exists(stopFilePath);

        public StopFlag(LongRunRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            string installDir = request.StopDir;
            stopFilePath = Path.Combine(installDir, "stop");
        }

        public void Remove()
        {
            File.Delete(stopFilePath);
        }
    }
}