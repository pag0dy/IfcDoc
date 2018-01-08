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

using BuildingSmart.IFC.IfcSharedBldgServiceElements;
using BuildingSmart.IFC.IfcSharedComponentElements;

namespace BuildingSmart.IFC.IfcHvacDomain
{
	[Guid("760a81f2-5681-4856-8e70-144d4bd1d61a")]
	public partial class IfcDuctFitting : IfcFlowFitting
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcDuctFittingTypeEnum? _PredefinedType;
	
	
		public IfcDuctFittingTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
