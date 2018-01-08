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
	[Guid("165e0478-cd28-4fb0-9f91-200d217e24b4")]
	public partial class IfcDraughtingCalloutRelationship
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLabel? _Name;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcText? _Description;
	
		[DataMember(Order=2)] 
		[Required()]
		IfcDraughtingCallout _RelatingDraughtingCallout;
	
		[DataMember(Order=3)] 
		[Required()]
		IfcDraughtingCallout _RelatedDraughtingCallout;
	
	
		[Description("The word or group of words by which the relationship is referred to.")]
		public IfcLabel? Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("Additional informal description of the relationship.")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
		[Description("One of the draughting callouts which is a part of the relationship.")]
		public IfcDraughtingCallout RelatingDraughtingCallout { get { return this._RelatingDraughtingCallout; } set { this._RelatingDraughtingCallout = value;} }
	
		[Description("The other of the draughting callouts which is a part of the relationship.")]
		public IfcDraughtingCallout RelatedDraughtingCallout { get { return this._RelatedDraughtingCallout; } set { this._RelatedDraughtingCallout = value;} }
	
	
	}
	
}
