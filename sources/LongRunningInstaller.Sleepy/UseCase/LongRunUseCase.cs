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

namespace LongRunningInstaller.Sleepy.UseCase
{
    public class LongRunUseCase
    {
        private readonly ILog log;

        public LongRunUseCase(ILog log)
        {
            this.log = log ?? throw new ArgumentNullException(nameof(log));
        }

        public void Execute(LongRunRequest request)
        {
            TimeSpan waitingTime = GetWaitingTime(request);
            log.WriteInfo($"Start sleeping: {waitingTime}");

            StopFlag stopFlag = new StopFlag(request);
            SleepyBob sleepyBob = new SleepyBob(waitingTime);

            while (true)
            {
                if (stopFlag.IsStopRequested)
                {
                    log.WriteInfo($"Stop was requested after {sleepyBob.Elapsed} time.");

                    try
                    {
                        stopFlag.Remove();
                    }
                    catch (Exception ex)
                    {
                        log.WriteInfo($"Stop flag could not be removed: {ex}");
                    }

                    break;
                }

                bool isFinished = sleepyBob.SleepNext();

                if (isFinished)
                    break;
            }

            log.WriteInfo($"Done sleeping: {sleepyBob.Elapsed}");
        }

        private TimeSpan GetWaitingTime(LongRunRequest request)
        {
            TimeSpan? timeSpan = request.GetWaitingTime();

            if (timeSpan.HasValue)
                return timeSpan.Value;

            log.WriteInfo("Waiting time was not provided. Using default value.");
            return TimeSpan.FromSeconds(10);
        }
    }
}