// This file may be edited manually or auto-generated using IfcKit at www.buildingsmart-tech.org.
// IFC content is copyright (C) 1996-2018 BuildingSMART International Ltd.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcStructuralLoadResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcStructuralAnalysisDomain
{
	public abstract partial class IfcStructuralActivity : IfcProduct
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("Load or result resource object which defines the load type, direction, and load values.    <p>In case of activities which are variably distributed over curves or surfaces, <em>IfcStructuralLoadConfiguration</em> is used which provides a list of load samples and their locations within the load distribution, measured in local coordinates of the curve or surface on which this activity acts.  The contents of this load or result distribution may be further restricted by definitions at subtypes of <em>IfcStructuralActivity</em>.</p>")]
		[Required()]
		public IfcStructuralLoad AppliedLoad { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Indicates whether the load directions refer to the global coordinate system (global to  the analysis model, i.e. as established by <em>IfcStructuralAnalysisModel.SharedPlacement</em>)  or to the local coordinate system (local to the activity or connected item, as established by  an explicit or implied representation and its parameter space).    <blockquote class=\"note\">NOTE, the informal definition of  <em>IfcRepresentationResource.IfcGlobalOrLocalEnum</em> doe s not distinguish between  &quot;global coordinate system&quot; and &quot;world coordinate system&quot;.  On the other hand, this distinction is necessary in the <em>IfcStructuralAnalysisDomain</em>  where the shared &quot;global&quot; coordinate system of an analysis model may very well  not be the same as the project-wide world coordinate system.</blockquote>    <blockquote class=\"note\">NOTE&nbsp; In the scope of <em>IfcStructuralActivity.GlobalOrLocal</em>,  the meaning of GLOBAL_COORDS is therefore not to be taken as world coordinate system  but as the analysis model specific shared coordinate system.  In contrast, LOCAL_COORDS  is to be taken as coordinates which are local to individual structural items and activities,  as established by subclass-specific geometry use definitions.</blockquote>")]
		[Required()]
		public IfcGlobalOrLocalEnum GlobalOrLocal { get; set; }
	
		[InverseProperty("RelatedStructuralActivity")] 
		[Description("Reference to the <em>IfcRelConnectsStructuralActivity</em> relationship by which activities are connected with structural items.")]
		[MaxLength(1)]
		public ISet<IfcRelConnectsStructuralActivity> AssignedToStructuralItem { get; protected set; }
	
	
		protected IfcStructuralActivity(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcStructuralLoad __AppliedLoad, IfcGlobalOrLocalEnum __GlobalOrLocal)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation)
		{
			this.AppliedLoad = __AppliedLoad;
			this.GlobalOrLocal = __GlobalOrLocal;
			this.AssignedToStructuralItem = new HashSet<IfcRelConnectsStructuralActivity>();
		}
	
	
	}
	
}
