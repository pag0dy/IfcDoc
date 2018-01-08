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
using BuildingSmart.IFC.IfcCostResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;

namespace BuildingSmart.IFC.IfcProcessExtension
{
	[Guid("77b2b704-db87-472e-a29a-8703008a914e")]
	public partial class IfcTaskType : IfcTypeProcess
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcTaskTypeEnum _PredefinedType;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLabel? _WorkMethod;
	
	
		[Description("<EPM-HTML>\r\n    Identifies the predefined types of a task type from which \r\n    t" +
	    "he type required may be set.\r\n</EPM-HTML>")]
		public IfcTaskTypeEnum PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
		[Description("<EPM-HTML>\r\n    The method of work used in carrying out a task.\r\n</EPM-HTML>")]
		public IfcLabel? WorkMethod { get { return this._WorkMethod; } set { this._WorkMethod = value;} }
	
	
	}
	
}
