; ModuleID = 'obj\Debug\130\android\marshal_methods.x86.ll'
source_filename = "obj\Debug\130\android\marshal_methods.x86.ll"
target datalayout = "e-m:e-p:32:32-p270:32:32-p271:32:32-p272:64:64-f64:32:64-f80:32-n8:16:32-S128"
target triple = "i686-unknown-linux-android"


%struct.MonoImage = type opaque

%struct.MonoClass = type opaque

%struct.MarshalMethodsManagedClass = type {
	i32,; uint32_t token
	%struct.MonoClass*; MonoClass* klass
}

%struct.MarshalMethodName = type {
	i64,; uint64_t id
	i8*; char* name
}

%class._JNIEnv = type opaque

%class._jobject = type {
	i8; uint8_t b
}

%class._jclass = type {
	i8; uint8_t b
}

%class._jstring = type {
	i8; uint8_t b
}

%class._jthrowable = type {
	i8; uint8_t b
}

%class._jarray = type {
	i8; uint8_t b
}

%class._jobjectArray = type {
	i8; uint8_t b
}

%class._jbooleanArray = type {
	i8; uint8_t b
}

%class._jbyteArray = type {
	i8; uint8_t b
}

%class._jcharArray = type {
	i8; uint8_t b
}

%class._jshortArray = type {
	i8; uint8_t b
}

%class._jintArray = type {
	i8; uint8_t b
}

%class._jlongArray = type {
	i8; uint8_t b
}

%class._jfloatArray = type {
	i8; uint8_t b
}

%class._jdoubleArray = type {
	i8; uint8_t b
}

; assembly_image_cache
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 4
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [190 x i32] [
	i32 32687329, ; 0: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 55
	i32 34715100, ; 1: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 84
	i32 57263871, ; 2: Xamarin.Forms.Core.dll => 0x369c6ff => 79
	i32 74292830, ; 3: PDC03FinalProject => 0x46d9e5e => 9
	i32 101534019, ; 4: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 69
	i32 120558881, ; 5: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 69
	i32 165246403, ; 6: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 36
	i32 182336117, ; 7: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 70
	i32 209399409, ; 8: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 34
	i32 230216969, ; 9: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 50
	i32 232815796, ; 10: System.Web.Services => 0xde07cb4 => 92
	i32 261689757, ; 11: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 39
	i32 278686392, ; 12: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 54
	i32 280482487, ; 13: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 48
	i32 318968648, ; 14: Xamarin.AndroidX.Activity.dll => 0x13031348 => 26
	i32 321597661, ; 15: System.Numerics => 0x132b30dd => 20
	i32 342366114, ; 16: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 52
	i32 347068432, ; 17: SQLitePCLRaw.lib.e_sqlite3.android.dll => 0x14afd810 => 13
	i32 385762202, ; 18: System.Memory.dll => 0x16fe439a => 19
	i32 441335492, ; 19: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 38
	i32 442521989, ; 20: Xamarin.Essentials => 0x1a605985 => 78
	i32 450948140, ; 21: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 47
	i32 465846621, ; 22: mscorlib => 0x1bc4415d => 7
	i32 469710990, ; 23: System.dll => 0x1bff388e => 18
	i32 476646585, ; 24: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 48
	i32 486930444, ; 25: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 59
	i32 526420162, ; 26: System.Transactions.dll => 0x1f6088c2 => 86
	i32 605376203, ; 27: System.IO.Compression.FileSystem => 0x24154ecb => 90
	i32 627609679, ; 28: Xamarin.AndroidX.CustomView => 0x2568904f => 43
	i32 663517072, ; 29: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 75
	i32 666292255, ; 30: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 31
	i32 690569205, ; 31: System.Xml.Linq.dll => 0x29293ff5 => 25
	i32 748832960, ; 32: SQLitePCLRaw.batteries_v2 => 0x2ca248c0 => 11
	i32 775507847, ; 33: System.IO.Compression => 0x2e394f87 => 89
	i32 809851609, ; 34: System.Drawing.Common.dll => 0x30455ad9 => 88
	i32 835661280, ; 35: MvvmHelpers.dll => 0x31cf2de0 => 8
	i32 843511501, ; 36: Xamarin.AndroidX.Print => 0x3246f6cd => 66
	i32 928116545, ; 37: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 84
	i32 967690846, ; 38: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 52
	i32 974778368, ; 39: FormsViewGroup.dll => 0x3a19f000 => 4
	i32 1012816738, ; 40: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 68
	i32 1017297409, ; 41: SQLitePCLRaw.provider.sqlite3.dll => 0x3ca2ba01 => 15
	i32 1034799549, ; 42: PDC03FinalProject.Android.dll => 0x3dadc9bd => 0
	i32 1035644815, ; 43: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 30
	i32 1042160112, ; 44: Xamarin.Forms.Platform.dll => 0x3e1e19f0 => 81
	i32 1052210849, ; 45: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 56
	i32 1098259244, ; 46: System => 0x41761b2c => 18
	i32 1175144683, ; 47: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 73
	i32 1178241025, ; 48: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 63
	i32 1204270330, ; 49: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 31
	i32 1267360935, ; 50: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 74
	i32 1292207520, ; 51: SQLitePCLRaw.core.dll => 0x4d0585a0 => 12
	i32 1293217323, ; 52: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 45
	i32 1365406463, ; 53: System.ServiceModel.Internals.dll => 0x516272ff => 93
	i32 1376866003, ; 54: Xamarin.AndroidX.SavedState => 0x52114ed3 => 68
	i32 1395857551, ; 55: Xamarin.AndroidX.Media.dll => 0x5333188f => 60
	i32 1406073936, ; 56: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 40
	i32 1411638395, ; 57: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 22
	i32 1460219004, ; 58: Xamarin.Forms.Xaml => 0x57092c7c => 82
	i32 1462112819, ; 59: System.IO.Compression.dll => 0x57261233 => 89
	i32 1469204771, ; 60: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 29
	i32 1582372066, ; 61: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 44
	i32 1592978981, ; 62: System.Runtime.Serialization.dll => 0x5ef2ee25 => 3
	i32 1622152042, ; 63: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 58
	i32 1624863272, ; 64: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 77
	i32 1636350590, ; 65: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 42
	i32 1639515021, ; 66: System.Net.Http.dll => 0x61b9038d => 2
	i32 1657153582, ; 67: System.Runtime => 0x62c6282e => 23
	i32 1658241508, ; 68: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 71
	i32 1658251792, ; 69: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 83
	i32 1670060433, ; 70: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 39
	i32 1700384458, ; 71: PDC03FinalProject.dll => 0x6559ceca => 9
	i32 1711441057, ; 72: SQLitePCLRaw.lib.e_sqlite3.android => 0x660284a1 => 13
	i32 1729485958, ; 73: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 35
	i32 1766324549, ; 74: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 70
	i32 1776026572, ; 75: System.Core.dll => 0x69dc03cc => 17
	i32 1788241197, ; 76: Xamarin.AndroidX.Fragment => 0x6a96652d => 47
	i32 1808609942, ; 77: Xamarin.AndroidX.Loader => 0x6bcd3296 => 58
	i32 1813201214, ; 78: Xamarin.Google.Android.Material => 0x6c13413e => 83
	i32 1818569960, ; 79: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 64
	i32 1867746548, ; 80: Xamarin.Essentials.dll => 0x6f538cf4 => 78
	i32 1878053835, ; 81: Xamarin.Forms.Xaml.dll => 0x6ff0d3cb => 82
	i32 1885316902, ; 82: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 32
	i32 1919157823, ; 83: Xamarin.AndroidX.MultiDex.dll => 0x7264063f => 61
	i32 2011961780, ; 84: System.Buffers.dll => 0x77ec19b4 => 16
	i32 2019465201, ; 85: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 56
	i32 2055257422, ; 86: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 53
	i32 2079903147, ; 87: System.Runtime.dll => 0x7bf8cdab => 23
	i32 2090596640, ; 88: System.Numerics.Vectors => 0x7c9bf920 => 21
	i32 2097448633, ; 89: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x7d0486b9 => 49
	i32 2103459038, ; 90: SQLitePCLRaw.provider.e_sqlite3.dll => 0x7d603cde => 14
	i32 2126786730, ; 91: Xamarin.Forms.Platform.Android => 0x7ec430aa => 80
	i32 2201231467, ; 92: System.Net.Http => 0x8334206b => 2
	i32 2217644978, ; 93: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 73
	i32 2244775296, ; 94: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 59
	i32 2256548716, ; 95: Xamarin.AndroidX.MultiDex => 0x8680336c => 61
	i32 2261435625, ; 96: Xamarin.AndroidX.Legacy.Support.V4.dll => 0x86cac4e9 => 51
	i32 2279755925, ; 97: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 67
	i32 2315684594, ; 98: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 27
	i32 2409053734, ; 99: Xamarin.AndroidX.Preference.dll => 0x8f973e26 => 65
	i32 2465273461, ; 100: SQLitePCLRaw.batteries_v2.dll => 0x92f11675 => 11
	i32 2465532216, ; 101: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 38
	i32 2471841756, ; 102: netstandard.dll => 0x93554fdc => 1
	i32 2475788418, ; 103: Java.Interop.dll => 0x93918882 => 5
	i32 2501346920, ; 104: System.Data.DataSetExtensions => 0x95178668 => 87
	i32 2505896520, ; 105: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 55
	i32 2581819634, ; 106: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 74
	i32 2620871830, ; 107: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 42
	i32 2624644809, ; 108: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 46
	i32 2633051222, ; 109: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 54
	i32 2701096212, ; 110: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 71
	i32 2732626843, ; 111: Xamarin.AndroidX.Activity => 0xa2e0939b => 26
	i32 2737747696, ; 112: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 29
	i32 2766581644, ; 113: Xamarin.Forms.Core => 0xa4e6af8c => 79
	i32 2778768386, ; 114: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 76
	i32 2810250172, ; 115: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 40
	i32 2819470561, ; 116: System.Xml.dll => 0xa80db4e1 => 24
	i32 2853208004, ; 117: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 76
	i32 2855708567, ; 118: Xamarin.AndroidX.Transition => 0xaa36a797 => 72
	i32 2903344695, ; 119: System.ComponentModel.Composition => 0xad0d8637 => 91
	i32 2905242038, ; 120: mscorlib.dll => 0xad2a79b6 => 7
	i32 2916838712, ; 121: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 77
	i32 2919462931, ; 122: System.Numerics.Vectors.dll => 0xae037813 => 21
	i32 2921128767, ; 123: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 28
	i32 2978675010, ; 124: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 45
	i32 3024354802, ; 125: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 50
	i32 3044182254, ; 126: FormsViewGroup => 0xb57288ee => 4
	i32 3057625584, ; 127: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 62
	i32 3111772706, ; 128: System.Runtime.Serialization => 0xb979e222 => 3
	i32 3204380047, ; 129: System.Data.dll => 0xbefef58f => 85
	i32 3211777861, ; 130: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 44
	i32 3247949154, ; 131: Mono.Security => 0xc197c562 => 94
	i32 3257332390, ; 132: MvvmHelpers => 0xc226f2a6 => 8
	i32 3258312781, ; 133: Xamarin.AndroidX.CardView => 0xc235e84d => 35
	i32 3267021929, ; 134: Xamarin.AndroidX.AsyncLayoutInflater => 0xc2bacc69 => 33
	i32 3286872994, ; 135: SQLite-net.dll => 0xc3e9b3a2 => 10
	i32 3317135071, ; 136: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 43
	i32 3317144872, ; 137: System.Data => 0xc5b79d28 => 85
	i32 3340431453, ; 138: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 32
	i32 3346324047, ; 139: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 63
	i32 3353484488, ; 140: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0xc7e21cc8 => 49
	i32 3360279109, ; 141: SQLitePCLRaw.core => 0xc849ca45 => 12
	i32 3362522851, ; 142: Xamarin.AndroidX.Core => 0xc86c06e3 => 41
	i32 3366347497, ; 143: Java.Interop => 0xc8a662e9 => 5
	i32 3370773189, ; 144: PDC03FinalProject.Android => 0xc8e9eac5 => 0
	i32 3374999561, ; 145: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 67
	i32 3395150330, ; 146: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 22
	i32 3404865022, ; 147: System.ServiceModel.Internals => 0xcaf21dfe => 93
	i32 3429136800, ; 148: System.Xml => 0xcc6479a0 => 24
	i32 3430777524, ; 149: netstandard => 0xcc7d82b4 => 1
	i32 3441283291, ; 150: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 46
	i32 3476120550, ; 151: Mono.Android => 0xcf3163e6 => 6
	i32 3486566296, ; 152: System.Transactions => 0xcfd0c798 => 86
	i32 3493954962, ; 153: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 37
	i32 3501239056, ; 154: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0xd0b0ab10 => 33
	i32 3509114376, ; 155: System.Xml.Linq => 0xd128d608 => 25
	i32 3521279769, ; 156: SQLitePCLRaw.provider.sqlite3 => 0xd1e27719 => 15
	i32 3536029504, ; 157: Xamarin.Forms.Platform.Android.dll => 0xd2c38740 => 80
	i32 3567349600, ; 158: System.ComponentModel.Composition.dll => 0xd4a16f60 => 91
	i32 3618140916, ; 159: Xamarin.AndroidX.Preference => 0xd7a872f4 => 65
	i32 3627220390, ; 160: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 66
	i32 3632359727, ; 161: Xamarin.Forms.Platform => 0xd881692f => 81
	i32 3633644679, ; 162: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 28
	i32 3641597786, ; 163: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 53
	i32 3672681054, ; 164: Mono.Android.dll => 0xdae8aa5e => 6
	i32 3676310014, ; 165: System.Web.Services.dll => 0xdb2009fe => 92
	i32 3682565725, ; 166: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 34
	i32 3684561358, ; 167: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 37
	i32 3689375977, ; 168: System.Drawing.Common => 0xdbe768e9 => 88
	i32 3718780102, ; 169: Xamarin.AndroidX.Annotation => 0xdda814c6 => 27
	i32 3724971120, ; 170: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 62
	i32 3754567612, ; 171: SQLitePCLRaw.provider.e_sqlite3 => 0xdfca27bc => 14
	i32 3758932259, ; 172: Xamarin.AndroidX.Legacy.Support.V4 => 0xe00cc123 => 51
	i32 3786282454, ; 173: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 36
	i32 3822602673, ; 174: Xamarin.AndroidX.Media => 0xe3d849b1 => 60
	i32 3829621856, ; 175: System.Numerics.dll => 0xe4436460 => 20
	i32 3876362041, ; 176: SQLite-net => 0xe70c9739 => 10
	i32 3885922214, ; 177: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 72
	i32 3896760992, ; 178: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 41
	i32 3920810846, ; 179: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 90
	i32 3921031405, ; 180: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 75
	i32 3931092270, ; 181: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 64
	i32 3945713374, ; 182: System.Data.DataSetExtensions.dll => 0xeb2ecede => 87
	i32 3955647286, ; 183: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 30
	i32 4025784931, ; 184: System.Memory => 0xeff49a63 => 19
	i32 4105002889, ; 185: Mono.Security.dll => 0xf4ad5f89 => 94
	i32 4151237749, ; 186: System.Core => 0xf76edc75 => 17
	i32 4182413190, ; 187: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 57
	i32 4260525087, ; 188: System.Buffers => 0xfdf2741f => 16
	i32 4292120959 ; 189: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 57
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [190 x i32] [
	i32 55, i32 84, i32 79, i32 9, i32 69, i32 69, i32 36, i32 70, ; 0..7
	i32 34, i32 50, i32 92, i32 39, i32 54, i32 48, i32 26, i32 20, ; 8..15
	i32 52, i32 13, i32 19, i32 38, i32 78, i32 47, i32 7, i32 18, ; 16..23
	i32 48, i32 59, i32 86, i32 90, i32 43, i32 75, i32 31, i32 25, ; 24..31
	i32 11, i32 89, i32 88, i32 8, i32 66, i32 84, i32 52, i32 4, ; 32..39
	i32 68, i32 15, i32 0, i32 30, i32 81, i32 56, i32 18, i32 73, ; 40..47
	i32 63, i32 31, i32 74, i32 12, i32 45, i32 93, i32 68, i32 60, ; 48..55
	i32 40, i32 22, i32 82, i32 89, i32 29, i32 44, i32 3, i32 58, ; 56..63
	i32 77, i32 42, i32 2, i32 23, i32 71, i32 83, i32 39, i32 9, ; 64..71
	i32 13, i32 35, i32 70, i32 17, i32 47, i32 58, i32 83, i32 64, ; 72..79
	i32 78, i32 82, i32 32, i32 61, i32 16, i32 56, i32 53, i32 23, ; 80..87
	i32 21, i32 49, i32 14, i32 80, i32 2, i32 73, i32 59, i32 61, ; 88..95
	i32 51, i32 67, i32 27, i32 65, i32 11, i32 38, i32 1, i32 5, ; 96..103
	i32 87, i32 55, i32 74, i32 42, i32 46, i32 54, i32 71, i32 26, ; 104..111
	i32 29, i32 79, i32 76, i32 40, i32 24, i32 76, i32 72, i32 91, ; 112..119
	i32 7, i32 77, i32 21, i32 28, i32 45, i32 50, i32 4, i32 62, ; 120..127
	i32 3, i32 85, i32 44, i32 94, i32 8, i32 35, i32 33, i32 10, ; 128..135
	i32 43, i32 85, i32 32, i32 63, i32 49, i32 12, i32 41, i32 5, ; 136..143
	i32 0, i32 67, i32 22, i32 93, i32 24, i32 1, i32 46, i32 6, ; 144..151
	i32 86, i32 37, i32 33, i32 25, i32 15, i32 80, i32 91, i32 65, ; 152..159
	i32 66, i32 81, i32 28, i32 53, i32 6, i32 92, i32 34, i32 37, ; 160..167
	i32 88, i32 27, i32 62, i32 14, i32 51, i32 36, i32 60, i32 20, ; 168..175
	i32 10, i32 72, i32 41, i32 90, i32 75, i32 64, i32 87, i32 30, ; 176..183
	i32 19, i32 94, i32 17, i32 57, i32 16, i32 57 ; 184..189
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 4; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 4

; Function attributes: "frame-pointer"="none" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 4
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 4
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="none" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" "stackrealign" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="none" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" "stackrealign" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"NumRegisterParameters", i32 0}
!3 = !{!"Xamarin.Android remotes/origin/d17-5 @ 45b0e144f73b2c8747d8b5ec8cbd3b55beca67f0"}
!llvm.linker.options = !{}
