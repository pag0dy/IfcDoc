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
	[Guid("f38b268f-5cb1-42c3-81e3-89081e6b0528")]
	public partial class IfcRelDeclares : IfcRelationship
	{
		[DataMember(Order=0)] 
		[XmlIgnore]
		[Required()]
		IfcContext _RelatingContext;
	
		[DataMember(Order=1)] 
		[Required()]
		[MinLength(1)]
		ISet<IfcDefinitionSelect> _RelatedDefinitions = new HashSet<IfcDefinitionSelect>();
	
	
		public IfcRelDeclares()
		{
		}
	
		public IfcRelDeclares(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcContext __RelatingContext, IfcDefinitionSelect[] __RelatedDefinitions)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this._RelatingContext = __RelatingContext;
			this._RelatedDefinitions = new HashSet<IfcDefinitionSelect>(__RelatedDefinitions);
		}
	
		[Description("Reference to the <em>IfcProject</em> to which additional information is assigned." +
	    "")]
		public IfcContext RelatingContext { get { return this._RelatingContext; } set { this._RelatingContext = value;} }
	
		[Description("Set of object or property definitions that are assigned to a context and to which" +
	    " the unit and representation context definitions of that context apply.")]
		public ISet<IfcDefinitionSelect> RelatedDefinitions { get { return this._RelatedDefinitions; } }
	
	
	}
	
}
