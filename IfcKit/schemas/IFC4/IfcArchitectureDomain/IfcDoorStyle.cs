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
using BuildingSmart.IFC.IfcSharedBldgElements;

namespace BuildingSmart.IFC.IfcArchitectureDomain
{
	[Guid("3e42e773-d2e7-4b27-8517-e04c42c4b1de")]
	public partial class IfcDoorStyle : IfcTypeProduct
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcDoorStyleOperationEnum _OperationType;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcDoorStyleConstructionEnum _ConstructionType;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcBoolean _ParameterTakesPrecedence;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		[Required()]
		IfcBoolean _Sizeable;
	
	
		[Description("Type defining the general layout and operation of the door style.\r\n<br>")]
		public IfcDoorStyleOperationEnum OperationType { get { return this._OperationType; } set { this._OperationType = value;} }
	
		[Description("Type defining the basic construction and material type of the door.\r\n<br>")]
		public IfcDoorStyleConstructionEnum ConstructionType { get { return this._ConstructionType; } set { this._ConstructionType = value;} }
	
		[Description(@"The Boolean value reflects, whether the parameter given in the attached lining and panel properties exactly define the geometry (TRUE), or whether the attached style shape take precedence (FALSE). In the last case the parameter have only informative value.
	<br>")]
		public IfcBoolean ParameterTakesPrecedence { get { return this._ParameterTakesPrecedence; } set { this._ParameterTakesPrecedence = value;} }
	
		[Description(@"The Boolean indicates, whether the attached <em>IfcMappedRepresentation</em> (if given) can be sized (using scale factor of transformation), or not (FALSE). If not, the <em>IfcMappedRepresentation</em> should be <em>IfcShapeRepresentation</em> of the <em>IfcDoor</em> (using <em>IfcMappedItem</em> as the <em>Item</em>) with the scale factor = 1.
	<br>")]
		public IfcBoolean Sizeable { get { return this._Sizeable; } set { this._Sizeable = value;} }
	
	
	}
	
}
