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


namespace BuildingSmart.IFC.IfcSharedBldgElements
{
	public enum IfcWindowTypePartitioningEnum
	{
		[Description("Window with one panel.")]
		SINGLE_PANEL = 1,
	
		[Description("Window with two panels. The configuration of the panels is vertically.")]
		DOUBLE_PANEL_VERTICAL = 2,
	
		[Description("Window with two panels. The configuration of the panels is horizontally.")]
		DOUBLE_PANEL_HORIZONTAL = 3,
	
		[Description("Window with three panels. The configuration of the panels is vertically.")]
		TRIPLE_PANEL_VERTICAL = 4,
	
		[Description("Window with three panels. The configuration of two panels is vertically and the\r\n" +
	    "third one is horizontally at the bottom.")]
		TRIPLE_PANEL_BOTTOM = 5,
	
		[Description("Window with three panels. The configuration of two panels is vertically and the\r\n" +
	    "third one is horizontally at the top.")]
		TRIPLE_PANEL_TOP = 6,
	
		[Description("Window with three panels. The configuration of two panels is horizontally and the" +
	    "\r\nthird one is vertically at the left hand side.")]
		TRIPLE_PANEL_LEFT = 7,
	
		[Description("Window with three panels. The configuration of two panels is horizontally and the" +
	    "\r\nthird one is vertically at the right hand side.")]
		TRIPLE_PANEL_RIGHT = 8,
	
		[Description("Window with three panels. The configuration of the panels is horizontally.")]
		TRIPLE_PANEL_HORIZONTAL = 9,
	
		[Description("User defined operation type.")]
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}
