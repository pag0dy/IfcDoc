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

using BuildingSmart.IFC.IfcActorResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProcessExtension;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcKernel
{
	[Guid("2b84a703-2870-4982-b755-d5e128989509")]
	public partial class IfcRelAssignsToProcess : IfcRelAssigns
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcProcessSelect _RelatingProcess;
	
		[DataMember(Order=1)] 
		[XmlElement("IfcMeasureWithUnit")]
		IfcMeasureWithUnit _QuantityInProcess;
	
	
		[Description("<EPM-HTML>\r\nReference to the process to which the objects are assigned to.\r\n<bloc" +
	    "kquote class=\"change-ifc2x4\">IFC4 CHANGE Datatype expanded to include <em>IfcPro" +
	    "cess</em> and <em>IfcTypeProcess</em>.</blockquote>\r\n</EPM-HTML>")]
		public IfcProcessSelect RelatingProcess { get { return this._RelatingProcess; } set { this._RelatingProcess = value;} }
	
		[Description("<EPM-HTML>\r\nQuantity of the object specific for the operation by this process.\r\n<" +
	    "/EPM-HTML>")]
		public IfcMeasureWithUnit QuantityInProcess { get { return this._QuantityInProcess; } set { this._QuantityInProcess = value;} }
	
	
	}
	
}
