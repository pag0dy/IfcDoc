// This file was automatically generated from IFCDOC at www.buildingsmart-tech.org.
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

namespace BuildingSmart.IFC.IfcPresentationDimensioningResource
{
	[Guid("be25928a-2cbb-435f-b070-c3afa0ead2f1")]
	public partial class IfcDimensionCalloutRelationship : IfcDraughtingCalloutRelationship
	{
	
		public IfcDimensionCalloutRelationship()
		{
		}
	
		public IfcDimensionCalloutRelationship(IfcLabel? __Name, IfcText? __Description, IfcDraughtingCallout __RelatingDraughtingCallout, IfcDraughtingCallout __RelatedDraughtingCallout)
			: base(__Name, __Description, __RelatingDraughtingCallout, __RelatedDraughtingCallout)
		{
		}
	
	
	}
	
}
