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

namespace BuildingSmart.IFC.IfcProfileResource
{
	[Guid("679c06da-711f-4ddc-9cd1-582f792b5ff8")]
	public partial class IfcCompositeProfileDef : IfcProfileDef
	{
		[DataMember(Order=0)] 
		[Required()]
		[MinLength(2)]
		ISet<IfcProfileDef> _Profiles = new HashSet<IfcProfileDef>();
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLabel? _Label;
	
	
		public IfcCompositeProfileDef()
		{
		}
	
		public IfcCompositeProfileDef(IfcProfileTypeEnum __ProfileType, IfcLabel? __ProfileName, IfcProfileDef[] __Profiles, IfcLabel? __Label)
			: base(__ProfileType, __ProfileName)
		{
			this._Profiles = new HashSet<IfcProfileDef>(__Profiles);
			this._Label = __Label;
		}
	
		[Description("The profiles which are used to define the composite profile.")]
		public ISet<IfcProfileDef> Profiles { get { return this._Profiles; } }
	
		[Description("The name by which the composition may be referred to. The actual meaning of the n" +
	    "ame has to be defined in the context of applications.")]
		public IfcLabel? Label { get { return this._Label; } set { this._Label = value;} }
	
	
	}
	
}
