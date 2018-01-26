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
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcProductExtension
{
	[Guid("e7fcbf9c-f9a1-43ab-b15f-56f0e33af740")]
	public partial class IfcSpaceType : IfcSpatialStructureElementType
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcSpaceTypeEnum _PredefinedType;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLabel? _LongName;
	
	
		public IfcSpaceType()
		{
		}
	
		public IfcSpaceType(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcIdentifier? __ApplicableOccurrence, IfcPropertySetDefinition[] __HasPropertySets, IfcRepresentationMap[] __RepresentationMaps, IfcLabel? __Tag, IfcLabel? __ElementType, IfcSpaceTypeEnum __PredefinedType, IfcLabel? __LongName)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ApplicableOccurrence, __HasPropertySets, __RepresentationMaps, __Tag, __ElementType)
		{
			this._PredefinedType = __PredefinedType;
			this._LongName = __LongName;
		}
	
		[Description("Predefined types to define the particular type of space. There may be property se" +
	    "t definitions available for each predefined type.")]
		public IfcSpaceTypeEnum PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
		[Description(@"Long name for a space type, used for informal purposes. It should be used, if available, in conjunction with the inherited <em>Name</em> attribute.
	<blockquote class=""note"">
	  NOTE&nbsp; In many scenarios the <em>Name</em> attribute refers to the short name or number of a space type, and the <em>LongName</em> refers to the full descriptive name.
	</blockquote>
	<blockquote class=""change-ifc2x4"">
	  IFC4 CHANGE&nbsp; New attribute added at the end of entity definition.
	</blockquote>")]
		public IfcLabel? LongName { get { return this._LongName; } set { this._LongName = value;} }
	
	
	}
	
}
