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
	[Guid("0ae997a0-8ed2-4ce0-aaf7-1b4d33ce64bb")]
	public partial class IfcRelAssignsToGroupByFactor : IfcRelAssignsToGroup
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcRatioMeasure _Factor;
	
	
		[Description("<EPM-HTML>\r\nFactor provided as a ratio measure that identifies the fraction or we" +
	    "ighted factor that applies to the group assignment.\r\n</EPM-HTML>")]
		public IfcRatioMeasure Factor { get { return this._Factor; } set { this._Factor = value;} }
	
	
	}
	
}
