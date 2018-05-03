// This file may be edited manually or auto-generated using IfcKit at www.buildingsmart-tech.org.
// IFC content is copyright (C) 1996-2018 BuildingSMART International Ltd.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;


namespace BuildingSmart.IFC.IfcArchitectureDomain
{
	public enum IfcWindowStyleOperationEnum
	{
		[Description("Window with one panel.")]
		SINGLE_PANEL = 1,
	
		[Description("Window with two panels. The configuration of the panels is vertically.")]
		DOUBLE_PANEL_VERTICAL = 2,
	
		[Description("Window with two panels. The configuration of the panels is\r\nhorizontally.")]
		DOUBLE_PANEL_HORIZONTAL = 3,
	
		[Description("Window with three panels. The configuration of the panels is\r\nvertically.")]
		TRIPLE_PANEL_VERTICAL = 4,
	
		[Description("Window with three panels. The configuration of two panels is vertically and\r\nthe " +
	    "third one is horizontally at the bottom.")]
		TRIPLE_PANEL_BOTTOM = 5,
	
		[Description("Window with three panels. The configuration of two panels is vertically and\r\nthe " +
	    "third one is horizontally at the top.")]
		TRIPLE_PANEL_TOP = 6,
	
		[Description("Window with three panels. The configuration of two panels is horizontally and\r\nth" +
	    "e third one is vertically at the left hand side.")]
		TRIPLE_PANEL_LEFT = 7,
	
		[Description("Window with three panels. The configuration of two panels is horizontally and\r\nth" +
	    "e third one is vertically at the right hand side.")]
		TRIPLE_PANEL_RIGHT = 8,
	
		[Description("Window with three panels. The configuration of the panels is horizontally.")]
		TRIPLE_PANEL_HORIZONTAL = 9,
	
		[Description("user defined operation type")]
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}
