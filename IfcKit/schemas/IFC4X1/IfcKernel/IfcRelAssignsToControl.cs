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
	[Guid("142af641-3046-4e25-8652-dbf0d05c61da")]
	public partial class IfcRelAssignsToControl : IfcRelAssigns
	{
		[DataMember(Order=0)] 
		[XmlElement]
		[Required()]
		IfcControl _RelatingControl;
	
	
		public IfcRelAssignsToControl()
		{
		}
	
		public IfcRelAssignsToControl(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcObjectDefinition[] __RelatedObjects, IfcObjectTypeEnum? __RelatedObjectsType, IfcControl __RelatingControl)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __RelatedObjects, __RelatedObjectsType)
		{
			this._RelatingControl = __RelatingControl;
		}
	
		[Description("Reference to the <em>IfcControl</em> that applies a control upon objects.")]
		public IfcControl RelatingControl { get { return this._RelatingControl; } set { this._RelatingControl = value;} }
	
	
	}
	
}
