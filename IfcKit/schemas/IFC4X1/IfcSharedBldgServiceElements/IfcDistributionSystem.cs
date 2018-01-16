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

namespace BuildingSmart.IFC.IfcSharedBldgServiceElements
{
	[Guid("08d5a5d6-3a9a-42d2-8411-5f268929c1fe")]
	public partial class IfcDistributionSystem : IfcSystem
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLabel? _LongName;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcDistributionSystemEnum? _PredefinedType;
	
	
		[Description(@"Long name for a distribution system, used for informal purposes. It should be used, if available, in conjunction with the inherited <em>Name</em> attribute.
	<blockquote class=""note"">NOTE&nbsp; In many scenarios the <em>Name</em> attribute refers to the short name or number of a distribution system or branch circuit, and the <em>LongName</em> refers to a descriptive name.
	</blockquote>")]
		public IfcLabel? LongName { get { return this._LongName; } set { this._LongName = value;} }
	
		[Description("Predefined types of distribution systems.")]
		public IfcDistributionSystemEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
