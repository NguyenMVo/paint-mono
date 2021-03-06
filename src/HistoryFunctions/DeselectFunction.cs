/////////////////////////////////////////////////////////////////////////////////
// Paint.NET                                                                   //
// Copyright (C) Rick Brewster, Tom Jackson, and past contributors.            //
// Portions Copyright (C) Microsoft Corporation. All Rights Reserved.          //
// See src/Resources/Files/License.txt for full licensing and attribution      //
// details.                                                                    //
// .                                                                           //
/////////////////////////////////////////////////////////////////////////////////

using PaintDotNet.Actions;
using PaintDotNet.HistoryMementos;
using System;
using System.Drawing;

namespace PaintDotNet.HistoryFunctions
{
    public sealed class DeselectFunction
        : HistoryFunction
    {
        public static string StaticName
        {
            get
            {
                return PdnResources.GetString("DeselectAction.Name");
            }
        }

        public static ImageResource StaticImage
        {
            get
            {
                return ImageResource.Get("Icons.MenuEditDeselectIcon.png");
            }
        }
        
        public override HistoryMemento OnExecute(IHistoryWorkspace historyWorkspace)
        {
            if (historyWorkspace.Selection.IsEmpty)
            {
                return null;
            }
            else
            {
                SelectionHistoryMemento sha = new SelectionHistoryMemento(StaticName, StaticImage, historyWorkspace);

                EnterCriticalRegion();
                historyWorkspace.Selection.Reset();

                return sha;
            }
        }

        public DeselectFunction()
            : base(ActionFlags.None)
        {
        }
    }
}
