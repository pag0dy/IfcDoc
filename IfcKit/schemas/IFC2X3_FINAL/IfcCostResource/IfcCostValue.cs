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

using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcCostResource
{
	[Guid("bf6a8525-e380-47d1-9e85-0eea04bf1bc5")]
	public partial class IfcCostValue : IfcAppliedValue,
		BuildingSmart.IFC.IfcConstraintResource.IfcMetricValueSelect
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcLabel _CostType;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcText? _Condition;
	
	
		[Description(@"<EPM-HTML>Specification of the type of cost type used.
	
	<BLOCKQUOTE>NOTE: There are many possible types of cost value that may be identified. Whilst there is a broad understanding of the meaning of names that may be assigned to different types of costs, there is no general standard for naming cost types nor are there any broadly defined classifications. To allow for any type of cost value, the IfcLabel datatype is assigned.</BLOCKQUOTE>
	 
	In the absence of any well defined standard, it is recommended that local agreements should be made to define allowable and understandable cost value types within a project or region.
	</EPM-HTML>
	
	")]
		public IfcLabel CostType { get { return this._CostType; } set { this._CostType = value;} }
	
		[Description("The condition under which a cost value applies.")]
		public IfcText? Condition { get { return this._Condition; } set { this._Condition = value;} }
	
	
	}
	
}
