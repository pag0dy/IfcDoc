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

using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcExternalReferenceResource
{
	[Guid("d82462fa-c9f8-472b-a7e9-0f1f7136fdfa")]
	public partial class IfcExternalReferenceRelationship : IfcResourceLevelRelationship
	{
		[DataMember(Order=0)] 
		[XmlElement]
		[Required()]
		IfcExternalReference _RelatingReference;
	
		[DataMember(Order=1)] 
		[Required()]
		[MinLength(1)]
		ISet<IfcResourceObjectSelect> _RelatedResourceObjects = new HashSet<IfcResourceObjectSelect>();
	
	
		public IfcExternalReferenceRelationship()
		{
		}
	
		public IfcExternalReferenceRelationship(IfcLabel? __Name, IfcText? __Description, IfcExternalReference __RelatingReference, IfcResourceObjectSelect[] __RelatedResourceObjects)
			: base(__Name, __Description)
		{
			this._RelatingReference = __RelatingReference;
			this._RelatedResourceObjects = new HashSet<IfcResourceObjectSelect>(__RelatedResourceObjects);
		}
	
		[Description(@"An external reference that can be used to tag an object within the range of <em>IfcResourceObjectSelect</em>.
	<blockquote class=""note"">
	NOTE&nbsp; External references can be a library reference (for example a dictionary or a catalogue reference), a classification reference, or a documentation reference.<br>
	</blockquote>")]
		public IfcExternalReference RelatingReference { get { return this._RelatingReference; } set { this._RelatingReference = value;} }
	
		[Description("Objects within the list of <em>IfcResourceObjectSelect</em> that can be tagged by" +
	    " an external reference to a dictionary, library, catalogue, classification or do" +
	    "cumentation.")]
		public ISet<IfcResourceObjectSelect> RelatedResourceObjects { get { return this._RelatedResourceObjects; } }
	
	
	}
	
}
