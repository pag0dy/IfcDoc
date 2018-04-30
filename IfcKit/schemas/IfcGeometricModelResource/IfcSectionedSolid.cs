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

using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;
using BuildingSmart.IFC.IfcProfileResource;

namespace BuildingSmart.IFC.IfcGeometricModelResource
{
	public abstract partial class IfcSectionedSolid : IfcSolidModel
	{
		[DataMember(Order = 0)] 
		[Description("The curve used to define the sweeping operation.")]
		[Required()]
		public IfcCurve Directrix { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("List of cross sections in sequential order along the <i>Directrix</i>.")]
		[Required()]
		[MinLength(2)]
		public IList<IfcProfileDef> CrossSections { get; protected set; }
	
	
		protected IfcSectionedSolid(IfcCurve __Directrix, IfcProfileDef[] __CrossSections)
		{
			this.Directrix = __Directrix;
			this.CrossSections = new List<IfcProfileDef>(__CrossSections);
		}
	
	
	}
	
}
