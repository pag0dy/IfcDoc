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

using BuildingSmart.IFC.IfcActorResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcRepresentationResource;

namespace BuildingSmart.IFC.IfcSharedBldgElements
{
	[Guid("0b5e3044-5232-4561-be29-c49fef5969d5")]
	public partial class IfcWindowType : IfcBuildingElementType
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcWindowTypeEnum _PredefinedType;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcWindowTypePartitioningEnum _PartitioningType;
	
		[DataMember(Order=2)] 
		Boolean? _ParameterTakesPrecedence;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcLabel? _UserDefinedPartitioningType;
	
	
		[Description("<EPM-HTML>\r\nIdentifies the predefined types of a window element from which the ty" +
	    "pe required may be set.\r\n</EPM-HTML>")]
		public IfcWindowTypeEnum PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
		[Description("<EPM-HTML>\r\nType defining the general layout of the window type in terms of the p" +
	    "artitioning of panels. \r\n</EPM-HTML>")]
		public IfcWindowTypePartitioningEnum PartitioningType { get { return this._PartitioningType; } set { this._PartitioningType = value;} }
	
		[Description(@"<EPM-HTML>
	The Boolean value reflects, whether the parameter given in the attached lining and panel properties exactly define the geometry (TRUE), or whether the attached style shape take precedence (FALSE). In the last case the parameter have only informative value. If not provided, no such information can be infered.
	</EPM-HTML>")]
		public Boolean? ParameterTakesPrecedence { get { return this._ParameterTakesPrecedence; } set { this._ParameterTakesPrecedence = value;} }
	
		[Description("<EPM-HTML>\r\nDesignator for the user defined partitioning type, shall only be prov" +
	    "ided, if the value of <em>PartitioningType</em> is set to USERDEFINED.\r\n</EPM-HT" +
	    "ML>")]
		public IfcLabel? UserDefinedPartitioningType { get { return this._UserDefinedPartitioningType; } set { this._UserDefinedPartitioningType = value;} }
	
	
	}
	
}
