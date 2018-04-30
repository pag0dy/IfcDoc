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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcPresentationDimensioningResource
{
	public partial class IfcDraughtingCallout : IfcGeometricRepresentationItem
	{
		[DataMember(Order = 0)] 
		[Description("The annotation curves, symbols, or text comprising the presentation of information.")]
		[Required()]
		[MinLength(1)]
		public ISet<IfcDraughtingCalloutElement> Contents { get; protected set; }
	
		[InverseProperty("RelatedDraughtingCallout")] 
		public ISet<IfcDraughtingCalloutRelationship> IsRelatedFromCallout { get; protected set; }
	
		[InverseProperty("RelatingDraughtingCallout")] 
		public ISet<IfcDraughtingCalloutRelationship> IsRelatedToCallout { get; protected set; }
	
	
		public IfcDraughtingCallout(IfcDraughtingCalloutElement[] __Contents)
		{
			this.Contents = new HashSet<IfcDraughtingCalloutElement>(__Contents);
			this.IsRelatedFromCallout = new HashSet<IfcDraughtingCalloutRelationship>();
			this.IsRelatedToCallout = new HashSet<IfcDraughtingCalloutRelationship>();
		}
	
	
	}
	
}
