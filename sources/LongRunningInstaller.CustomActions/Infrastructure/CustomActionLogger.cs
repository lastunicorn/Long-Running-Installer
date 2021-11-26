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
using System.Runtime.CompilerServices;
using DustInTheWind.LongRunningInstaller.TextControls;
using Microsoft.Deployment.WindowsInstaller;

namespace DustInTheWind.LongRunningInstaller.CustomActions.Infrastructure
{
    internal class CustomActionLogger : IDisposable
    {
        private readonly Session session;
        private readonly string callerMethodName;

        public CustomActionLogger(Session session, [CallerMemberName] string callerMethodName = null)
        {
            this.session = session ?? throw new ArgumentNullException(nameof(session));
            this.callerMethodName = callerMethodName;
            
            session.Log(new Title($"Begin {callerMethodName}"));
        }

        public void Dispose()
        {
            session.Log(new Title($"End {callerMethodName}"));
        }
    }
}