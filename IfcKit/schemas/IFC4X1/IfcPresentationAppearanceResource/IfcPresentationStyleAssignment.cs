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


namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	[Guid("3ca4cc70-a4c3-45fa-8e65-f85288defd8b")]
	public partial class IfcPresentationStyleAssignment :
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcStyleAssignmentSelect
	{
		[DataMember(Order=0)] 
		[Required()]
		[MinLength(1)]
		ISet<IfcPresentationStyleSelect> _Styles = new HashSet<IfcPresentationStyleSelect>();
	
	
		public IfcPresentationStyleAssignment()
		{
		}
	
		public IfcPresentationStyleAssignment(IfcPresentationStyleSelect[] __Styles)
		{
			this._Styles = new HashSet<IfcPresentationStyleSelect>(__Styles);
		}
	
		[Description("A set of presentation styles that are assigned to styled items.")]
		public ISet<IfcPresentationStyleSelect> Styles { get { return this._Styles; } }
	
	
	}
	
}
