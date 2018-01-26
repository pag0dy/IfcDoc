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
	[Guid("2127538d-266b-4b8d-a595-3ef8afe2acf0")]
	public abstract partial class IfcRelDefines : IfcRelationship
	{
		[DataMember(Order=0)] 
		[Required()]
		[MinLength(1)]
		ISet<IfcObject> _RelatedObjects = new HashSet<IfcObject>();
	
	
		public IfcRelDefines()
		{
		}
	
		public IfcRelDefines(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcObject[] __RelatedObjects)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this._RelatedObjects = new HashSet<IfcObject>(__RelatedObjects);
		}
	
		[Description("Reference to the objects (or single object) to which the property definition appl" +
	    "ies.\r\n")]
		public ISet<IfcObject> RelatedObjects { get { return this._RelatedObjects; } }
	
	
	}
	
}
