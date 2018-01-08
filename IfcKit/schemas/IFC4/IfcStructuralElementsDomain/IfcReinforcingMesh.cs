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

using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcSharedComponentElements;

namespace BuildingSmart.IFC.IfcStructuralElementsDomain
{
	[Guid("60c27225-1396-4914-94fa-e4ace351eb81")]
	public partial class IfcReinforcingMesh : IfcReinforcingElement
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _MeshLength;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _MeshWidth;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _LongitudinalBarNominalDiameter;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _TransverseBarNominalDiameter;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcAreaMeasure? _LongitudinalBarCrossSectionArea;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		IfcAreaMeasure? _TransverseBarCrossSectionArea;
	
		[DataMember(Order=6)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _LongitudinalBarSpacing;
	
		[DataMember(Order=7)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _TransverseBarSpacing;
	
		[DataMember(Order=8)] 
		[XmlAttribute]
		IfcReinforcingMeshTypeEnum? _PredefinedType;
	
	
		[Description("<EPM-HTML>\r\n\r\nDeprecated.\r\n\r\n<blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; " +
	    "Attribute deprecated.  Use respective attribute at <em>IfcReinforcingMeshType</e" +
	    "m> instead.</blockquote>\r\n\r\n</EPM-HTML>")]
		public IfcPositiveLengthMeasure? MeshLength { get { return this._MeshLength; } set { this._MeshLength = value;} }
	
		[Description("<EPM-HTML>\r\n\r\nDeprecated.\r\n\r\n<blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; " +
	    "Attribute deprecated.  Use respective attribute at <em>IfcReinforcingMeshType</e" +
	    "m> instead.</blockquote>\r\n\r\n</EPM-HTML>")]
		public IfcPositiveLengthMeasure? MeshWidth { get { return this._MeshWidth; } set { this._MeshWidth = value;} }
	
		[Description("<EPM-HTML>\r\n\r\nDeprecated.\r\n\r\n<blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; " +
	    "Attribute made optional and deprecated.  Use respective attribute at <em>IfcRein" +
	    "forcingMeshType</em> instead.</blockquote>\r\n\r\n</EPM-HTML>")]
		public IfcPositiveLengthMeasure? LongitudinalBarNominalDiameter { get { return this._LongitudinalBarNominalDiameter; } set { this._LongitudinalBarNominalDiameter = value;} }
	
		[Description("<EPM-HTML>\r\n\r\nDeprecated.\r\n\r\n<blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; " +
	    "Attribute made optional and deprecated.  Use respective attribute at <em>IfcRein" +
	    "forcingMeshType</em> instead.</blockquote>\r\n\r\n</EPM-HTML>")]
		public IfcPositiveLengthMeasure? TransverseBarNominalDiameter { get { return this._TransverseBarNominalDiameter; } set { this._TransverseBarNominalDiameter = value;} }
	
		[Description("<EPM-HTML>\r\n\r\nDeprecated.\r\n\r\n<blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; " +
	    "Attribute made optional and deprecated.  Use respective attribute at <em>IfcRein" +
	    "forcingMeshType</em> instead.</blockquote>\r\n\r\n</EPM-HTML>")]
		public IfcAreaMeasure? LongitudinalBarCrossSectionArea { get { return this._LongitudinalBarCrossSectionArea; } set { this._LongitudinalBarCrossSectionArea = value;} }
	
		[Description("<EPM-HTML>\r\n\r\nDeprecated.\r\n\r\n<blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; " +
	    "Attribute made optional and deprecated.  Use respective attribute at <em>IfcRein" +
	    "forcingMeshType</em> instead.</blockquote>\r\n\r\n</EPM-HTML>")]
		public IfcAreaMeasure? TransverseBarCrossSectionArea { get { return this._TransverseBarCrossSectionArea; } set { this._TransverseBarCrossSectionArea = value;} }
	
		[Description("<EPM-HTML>\r\n\r\nDeprecated.\r\n\r\n<blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; " +
	    "Attribute made optional and deprecated.  Use respective attribute at <em>IfcRein" +
	    "forcingMeshType</em> instead.</blockquote>\r\n\r\n</EPM-HTML>")]
		public IfcPositiveLengthMeasure? LongitudinalBarSpacing { get { return this._LongitudinalBarSpacing; } set { this._LongitudinalBarSpacing = value;} }
	
		[Description("<EPM-HTML>\r\n\r\nDeprecated.\r\n\r\n<blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; " +
	    "Attribute made optional and deprecated.  Use respective attribute at <em>IfcRein" +
	    "forcingMeshType</em> instead.</blockquote>\r\n\r\n</EPM-HTML>")]
		public IfcPositiveLengthMeasure? TransverseBarSpacing { get { return this._TransverseBarSpacing; } set { this._TransverseBarSpacing = value;} }
	
		[Description("Kind of mesh.")]
		public IfcReinforcingMeshTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
