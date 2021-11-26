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
using DustInTheWind.LongRunningInstaller.CustomActions.Infrastructure;
using LongRunningInstaller.Sleepy.UseCase;
using Microsoft.Deployment.WindowsInstaller;

namespace DustInTheWind.LongRunningInstaller.CustomActions
{
    public static class CustomActions
    {
        [CustomAction]
        public static ActionResult LongRun(Session session)
        {
            using (new CustomActionLogger(session))
            {
                Log log = new Log(session);

                try
                {
                    LogRunProperties properties = new LogRunProperties(session);
                    LongRunRequest request = new LongRunRequest
                    {
                        Seconds = properties.Seconds,
                        Time = properties.Time,
                        StopDir = properties.StopDir
                    };

                    LongRunUseCase useCase = new LongRunUseCase(log);
                    useCase.Execute(request);

                    return ActionResult.Success;
                }
                catch (Exception ex)
                {
                    log.WriteError(ex);
                    return ActionResult.Failure;
                }
            }
        }
    }
}