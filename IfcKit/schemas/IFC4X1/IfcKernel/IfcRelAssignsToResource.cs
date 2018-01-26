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
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcKernel
{
	[Guid("8e3fe369-7b2f-42e1-ba03-10771a673e88")]
	public partial class IfcRelAssignsToResource : IfcRelAssigns
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcResourceSelect _RelatingResource;
	
	
		public IfcRelAssignsToResource()
		{
		}
	
		public IfcRelAssignsToResource(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcObjectDefinition[] __RelatedObjects, IfcObjectTypeEnum? __RelatedObjectsType, IfcResourceSelect __RelatingResource)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __RelatedObjects, __RelatedObjectsType)
		{
			this._RelatingResource = __RelatingResource;
		}
	
		[Description("Reference to the resource to which the objects are assigned to.\r\n<blockquote clas" +
	    "s=\"change-ifc2x4\">IFC4 CHANGE Datatype expanded to include <em>IfcResource</em> " +
	    "and <em>IfcTypeResource</em>.</blockquote>")]
		public IfcResourceSelect RelatingResource { get { return this._RelatingResource; } set { this._RelatingResource = value;} }
	
	
	}
	
}
