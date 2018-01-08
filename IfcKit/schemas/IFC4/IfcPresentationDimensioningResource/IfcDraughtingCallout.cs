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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationDefinitionResource;
using BuildingSmart.IFC.IfcPresentationResource;

namespace BuildingSmart.IFC.IfcPresentationDimensioningResource
{
	[Guid("496e47c8-49ce-4c2e-9fa3-0d3bf431a002")]
	public partial class IfcDraughtingCallout : IfcGeometricRepresentationItem
	{
		[DataMember(Order=0)] 
		[Required()]
		ISet<IfcDraughtingCalloutElement> _Contents = new HashSet<IfcDraughtingCalloutElement>();
	
		[InverseProperty("RelatedDraughtingCallout")] 
		ISet<IfcDraughtingCalloutRelationship> _IsRelatedFromCallout = new HashSet<IfcDraughtingCalloutRelationship>();
	
		[InverseProperty("RelatingDraughtingCallout")] 
		ISet<IfcDraughtingCalloutRelationship> _IsRelatedToCallout = new HashSet<IfcDraughtingCalloutRelationship>();
	
	
		[Description("The annotation curves, symbols, or text comprising the presentation of informatio" +
	    "n.")]
		public ISet<IfcDraughtingCalloutElement> Contents { get { return this._Contents; } }
	
		public ISet<IfcDraughtingCalloutRelationship> IsRelatedFromCallout { get { return this._IsRelatedFromCallout; } }
	
		public ISet<IfcDraughtingCalloutRelationship> IsRelatedToCallout { get { return this._IsRelatedToCallout; } }
	
	
	}
	
}
