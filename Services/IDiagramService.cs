#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using EJ2CoreSampleBrowser.Models;

namespace EJ2CoreSampleBrowser.Services
{
    public interface IDiagramService
    {
        Task<DiagramData?> GetDiagramAsync(string diagramId);
        Task<bool> SaveDiagramDataAsync(string diagramId, string diagramData, string userId);
    }
}