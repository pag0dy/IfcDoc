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
	[Guid("644f260a-0347-4e6a-84b2-be14f6c42b87")]
	public partial class IfcDoorType : IfcBuildingElementType
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcDoorTypeEnum _PredefinedType;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcDoorTypeOperationEnum _OperationType;
	
		[DataMember(Order=2)] 
		Boolean? _ParameterTakesPrecedence;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcLabel? _UserDefinedOperationType;
	
	
		[Description("<EPM-HTML>\r\nIdentifies the predefined types of a door element from which the type" +
	    " required may be set.\r\n</EPM-HTML>")]
		public IfcDoorTypeEnum PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
		[Description("<EPM-HTML>\r\nType defining the general layout and operation of the door type in te" +
	    "rms of the partitioning of panels and panel operations. \r\n</EPM-HTML>")]
		public IfcDoorTypeOperationEnum OperationType { get { return this._OperationType; } set { this._OperationType = value;} }
	
		[Description(@"<EPM-HTML>
	The Boolean value reflects, whether the parameter given in the attached lining and panel properties exactly define the geometry (TRUE), or whether the attached style shape take precedence (FALSE). In the last case the parameter have only informative value. If not provided, no such information can be infered.
	</EPM-HTML>")]
		public Boolean? ParameterTakesPrecedence { get { return this._ParameterTakesPrecedence; } set { this._ParameterTakesPrecedence = value;} }
	
		[Description("<EPM-HTML>\r\nDesignator for the user defined operation type, shall only be provide" +
	    "d, if the value of <em>OperationType</em> is set to USERDEFINED.\r\n</EPM-HTML>")]
		public IfcLabel? UserDefinedOperationType { get { return this._UserDefinedOperationType; } set { this._UserDefinedOperationType = value;} }
	
	
	}
	
}
