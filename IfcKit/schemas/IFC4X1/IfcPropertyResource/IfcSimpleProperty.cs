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

using BuildingSmart.IFC.IfcApprovalResource;
using BuildingSmart.IFC.IfcConstraintResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcPropertyResource
{
	[Guid("6754d0f9-1ae8-4653-bbab-f9aa6b1e5206")]
	public abstract partial class IfcSimpleProperty : IfcProperty
	{
	
		public IfcSimpleProperty()
		{
		}
	
		public IfcSimpleProperty(IfcIdentifier __Name, IfcText? __Description)
			: base(__Name, __Description)
		{
		}
	
	
	}
	
}
