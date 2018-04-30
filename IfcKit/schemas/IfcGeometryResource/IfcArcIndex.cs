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

using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	public partial struct IfcArcIndex :
		BuildingSmart.IFC.IfcGeometryResource.IfcSegmentIndexSelect
	{
		[XmlText]
		public IfcPositiveInteger Value { get; private set; }
	
		public IfcArcIndex(IfcPositiveInteger value) : this()
		{
			this.Value = value;
		}
		public IfcArcIndex(IfcInteger value) : this()
		{
			this.Value = new IfcPositiveInteger(value);
		}
	}
	
}
