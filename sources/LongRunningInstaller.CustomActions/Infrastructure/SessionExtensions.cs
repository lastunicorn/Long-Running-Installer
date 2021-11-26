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
using Microsoft.Deployment.WindowsInstaller;

namespace DustInTheWind.LongRunningInstaller.CustomActions.Infrastructure
{
    internal static class SessionExtensions
    {
        public static int GetInt(this Session session, string propertyName)
        {
            int? value = session.GetIntOptional(propertyName);

            return value ?? throw new Exception($"The property {propertyName} does not exist.");
        }

        public static int? GetIntOptional(this Session session, string propertyName)
        {
            bool isDeferredMode = session.IsDeferredMode();

            string rawValue = isDeferredMode
                ? session.CustomActionData[propertyName] // deferred
                : session[propertyName]; // immediate

            if (string.IsNullOrEmpty(rawValue))
                return null;

            bool isParseSuccessful = int.TryParse(rawValue, out int value);

            if (!isParseSuccessful)
                throw new Exception($"The property {propertyName} could not be converted to an integer. Value = {rawValue}");

            return value;
        }

        public static TimeSpan GetTimeSpan(this Session session, string propertyName)
        {
            TimeSpan? value = session.GetTimeSpanOptional(propertyName);

            return value ?? throw new Exception($"The property {propertyName} does not exist.");
        }

        public static TimeSpan? GetTimeSpanOptional(this Session session, string propertyName)
        {
            bool isDeferredMode = session.IsDeferredMode();

            string rawValue = isDeferredMode
                ? session.CustomActionData[propertyName] // deferred
                : session[propertyName]; // immediate

            if (string.IsNullOrEmpty(rawValue))
                return null;

            bool isParseSuccessful = TimeSpan.TryParse(rawValue, out TimeSpan value);

            if (!isParseSuccessful)
                throw new Exception($"The property {propertyName} could not be converted to a TimeSpan. Value = {rawValue}");

            return value;
        }

        public static string GetString(this Session session, string propertyName)
        {
            bool isDeferredMode = session.IsDeferredMode();

            string rawValue = isDeferredMode
                ? session.CustomActionData[propertyName] // deferred
                : session[propertyName]; // immediate

            return string.IsNullOrEmpty(rawValue)
                ? null
                : rawValue;
        }

        private static bool IsDeferredMode(this Session session)
        {
            bool isScheduledMode = session.GetMode(InstallRunMode.Scheduled);
            bool isRollbackMode = session.GetMode(InstallRunMode.Rollback);
            bool isCommitMode = session.GetMode(InstallRunMode.Commit);

            return isScheduledMode || isRollbackMode || isCommitMode;
        }
    }
}