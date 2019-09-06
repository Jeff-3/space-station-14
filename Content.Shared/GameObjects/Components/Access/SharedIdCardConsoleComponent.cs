using System;
using System.Collections.Generic;
using Robust.Shared.GameObjects;
using Robust.Shared.GameObjects.Components.UserInterface;
using Robust.Shared.Serialization;

namespace Content.Shared.GameObjects.Components.Access
{
    public class SharedIdCardConsoleComponent : Component
    {
        public override string Name => "IdCardConsole";

        public enum UiButton
        {
            PrivilegedId,
            TargetId,
        }

        [Serializable, NetSerializable]
        public class IdButtonPressedMessage : BoundUserInterfaceMessage
        {
            public readonly UiButton Button;

            public IdButtonPressedMessage(UiButton button)
            {
                Button = button;
            }
        }

        [Serializable, NetSerializable]
        public class WriteToTargetIdMessage : BoundUserInterfaceMessage
        {
            public readonly string FullName;
            public readonly string JobTitle;
            public readonly List<string> AccessList;

            public WriteToTargetIdMessage(string fullName, string jobTitle, List<string> accessList)
            {
                FullName = fullName;
                JobTitle = jobTitle;
                AccessList = accessList;
            }
        }

        [Serializable, NetSerializable]
        public class IdCardConsoleBoundUserInterfaceState : BoundUserInterfaceState
        {
            public readonly bool IsPrivilegedIdPresent;
            public readonly bool IsPrivilegedIdAuthorized;
            public readonly bool IsTargetIdPresent;
            public readonly string TargetIdFullName;
            public readonly string TargetIdJobTitle;
            public readonly List<string> TargetIdAccessList;

            public IdCardConsoleBoundUserInterfaceState(bool isPrivilegedIdPresent,
                bool isPrivilegedIdAuthorized,
                bool isTargetIdPresent,
                string targetIdFullName,
                string targetIdJobTitle,
                List<string> targetIdAccessList)
            {
                IsPrivilegedIdPresent = isPrivilegedIdPresent;
                IsPrivilegedIdAuthorized = isPrivilegedIdAuthorized;
                IsTargetIdPresent = isTargetIdPresent;
                TargetIdFullName = targetIdFullName;
                TargetIdJobTitle = targetIdJobTitle;
                TargetIdAccessList = targetIdAccessList;
            }
        }

        [Serializable, NetSerializable]
        public enum IdCardConsoleUiKey
        {
            Key,
        }
    }
}