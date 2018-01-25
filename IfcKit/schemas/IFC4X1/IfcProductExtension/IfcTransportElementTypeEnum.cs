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
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcQuantityResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcSharedBldgElements;
using BuildingSmart.IFC.IfcSharedBldgServiceElements;
using BuildingSmart.IFC.IfcSharedComponentElements;
using BuildingSmart.IFC.IfcSharedFacilitiesElements;
using BuildingSmart.IFC.IfcStructuralElementsDomain;

namespace BuildingSmart.IFC.IfcProductExtension
{
	[Guid("1d2ff367-4801-42c9-ab52-201b9879cc70")]
	public enum IfcTransportElementTypeEnum
	{
		[Description("Elevator or lift being a transport device to move people of good vertically.")]
		ELEVATOR = 1,
	
		[Description("Escalator being a transport device to move people. It consists of individual link" +
	    "ed steps that move up and down on tracks while keeping the threads horizontal.")]
		ESCALATOR = 2,
	
		[Description("Moving walkway being a transport device to move people horizontally or on an incl" +
	    "ine. It is a slow conveyor belt that transports people.")]
		MOVINGWALKWAY = 3,
	
		[Description("A crane way system, normally including the crane rails, fasteners and the crane. " +
	    "It is primarily used to move heavy goods in a factory or other industry building" +
	    "s.")]
		CRANEWAY = 4,
	
		[Description("A device used for lifting or lowering heavy goods. It may be manually operated or" +
	    " electrically or pneumatically driven.")]
		LIFTINGGEAR = 5,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}
