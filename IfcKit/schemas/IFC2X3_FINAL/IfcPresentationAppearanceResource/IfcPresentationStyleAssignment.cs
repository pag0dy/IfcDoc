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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationDefinitionResource;
using BuildingSmart.IFC.IfcPresentationResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	[Guid("e326c64a-8856-4461-8ad5-ae1a33480ef7")]
	public partial class IfcPresentationStyleAssignment
	{
		[DataMember(Order=0)] 
		[Required()]
		ISet<IfcPresentationStyleSelect> _Styles = new HashSet<IfcPresentationStyleSelect>();
	
	
		[Description("A set of presentation styles that are assigned to styled items.")]
		public ISet<IfcPresentationStyleSelect> Styles { get { return this._Styles; } }
	
	
	}
	
}
