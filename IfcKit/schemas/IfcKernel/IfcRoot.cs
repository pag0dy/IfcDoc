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
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcKernel
{
	public abstract partial class IfcRoot
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Assignment of a globally unique identifier within the entire software world.  ")]
		[Required()]
		[CustomValidation(typeof(IfcRoot), "Unique")]
		public IfcGloballyUniqueId GlobalId { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlElement]
		[Description("Assignment of the information about the current ownership of that object, including owning actor, application, local identification and information captured about the recent changes of the object,     <blockquote class=\"note\">NOTE&nbsp; only the last modification in stored - either as addition, deletion or modification.</blockquote>  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; The attribute has been changed to be OPTIONAL.</blockquote>")]
		public IfcOwnerHistory OwnerHistory { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Optional name for use by the participating software systems or users. For some subtypes of IfcRoot the insertion of the Name attribute may be required. This would be enforced by a where rule.  ")]
		public IfcLabel? Name { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Optional description, provided for exchanging informative comments.")]
		public IfcText? Description { get; set; }
	
	
		protected IfcRoot(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description)
		{
			this.GlobalId = __GlobalId;
			this.OwnerHistory = __OwnerHistory;
			this.Name = __Name;
			this.Description = __Description;
		}
	
	
	}
	
}
