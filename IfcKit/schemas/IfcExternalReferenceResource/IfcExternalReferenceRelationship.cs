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

namespace BuildingSmart.IFC.IfcExternalReferenceResource
{
	public partial class IfcExternalReferenceRelationship : IfcResourceLevelRelationship
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("An external reference that can be used to tag an object within the range of <em>IfcResourceObjectSelect</em>.   <blockquote class=\"note\">   NOTE&nbsp; External references can be a library reference (for example a dictionary or a catalogue reference), a classification reference, or a documentation reference.<br>  </blockquote>")]
		[Required()]
		public IfcExternalReference RelatingReference { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("Objects within the list of <em>IfcResourceObjectSelect</em> that can be tagged by an external reference to a dictionary, library, catalogue, classification or documentation.")]
		[Required()]
		[MinLength(1)]
		public ISet<IfcResourceObjectSelect> RelatedResourceObjects { get; protected set; }
	
	
		public IfcExternalReferenceRelationship(IfcLabel? __Name, IfcText? __Description, IfcExternalReference __RelatingReference, IfcResourceObjectSelect[] __RelatedResourceObjects)
			: base(__Name, __Description)
		{
			this.RelatingReference = __RelatingReference;
			this.RelatedResourceObjects = new HashSet<IfcResourceObjectSelect>(__RelatedResourceObjects);
		}
	
	
	}
	
}
