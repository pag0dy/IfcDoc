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

using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcKernel
{
	[Guid("a6744c81-6540-4918-b206-1d28320b2ee7")]
	public partial class IfcPropertySet : IfcPropertySetDefinition
	{
		[DataMember(Order=0)] 
		[Required()]
		[MinLength(1)]
		ISet<IfcProperty> _HasProperties = new HashSet<IfcProperty>();
	
	
		public IfcPropertySet()
		{
		}
	
		public IfcPropertySet(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcProperty[] __HasProperties)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this._HasProperties = new HashSet<IfcProperty>(__HasProperties);
		}
	
		[Description(@"Contained set of properties. For property sets defined as part of the IFC Object model, the property objects within a property set are defined as part of the standard. If a property is not contained within the set of predefined properties, its value has not been set at this time.
	")]
		public ISet<IfcProperty> HasProperties { get { return this._HasProperties; } }
	
	
	}
	
}
