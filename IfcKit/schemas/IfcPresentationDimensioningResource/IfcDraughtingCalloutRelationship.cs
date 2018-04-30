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

namespace BuildingSmart.IFC.IfcPresentationDimensioningResource
{
	public partial class IfcDraughtingCalloutRelationship
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The word or group of words by which the relationship is referred to.")]
		public IfcLabel? Name { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Additional informal description of the relationship.")]
		public IfcText? Description { get; set; }
	
		[DataMember(Order = 2)] 
		[Description("One of the draughting callouts which is a part of the relationship.")]
		[Required()]
		public IfcDraughtingCallout RelatingDraughtingCallout { get; set; }
	
		[DataMember(Order = 3)] 
		[Description("The other of the draughting callouts which is a part of the relationship.")]
		[Required()]
		public IfcDraughtingCallout RelatedDraughtingCallout { get; set; }
	
	
		public IfcDraughtingCalloutRelationship(IfcLabel? __Name, IfcText? __Description, IfcDraughtingCallout __RelatingDraughtingCallout, IfcDraughtingCallout __RelatedDraughtingCallout)
		{
			this.Name = __Name;
			this.Description = __Description;
			this.RelatingDraughtingCallout = __RelatingDraughtingCallout;
			this.RelatedDraughtingCallout = __RelatedDraughtingCallout;
		}
	
	
	}
	
}
