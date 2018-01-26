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

using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcStructuralAnalysisDomain;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcSharedBldgElements
{
	[Guid("b68d6dfa-32ba-4dd2-a0b7-2e703624e4b5")]
	public partial class IfcRailing : IfcBuildingElement
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcRailingTypeEnum? _PredefinedType;
	
	
		public IfcRailing()
		{
		}
	
		public IfcRailing(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcIdentifier? __Tag, IfcRailingTypeEnum? __PredefinedType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __Tag)
		{
			this._PredefinedType = __PredefinedType;
		}
	
		[Description(@"<EPM-HTML>
	Predefined generic types for a railing that are specified in an enumeration. There may be a property set given for the predefined types.
	<BLOCKQUOTE> <FONT SIZE=""-1"">NOTE: The use of the predefined type directly at the occurrence object level of <I>IfcRailing</I> is only permitted, if no type object <I>IfcRailingType</I> is assigned.</FONT></BLOCKQUOTE>
	<BLOCKQUOTE> <FONT COLOR=""#FF0000"" SIZE=""-1"">IFC2x PLATFORM CHANGE: The attribute has been changed into an OPTIONAL attribute. </FONT></BLOCKQUOTE>
	</EPM-HTML> ")]
		public IfcRailingTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
