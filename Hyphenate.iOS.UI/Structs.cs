using System;
using ObjCRuntime;

namespace Hyphenate.iOS.UI
{
	public enum DXDeleteConvesationType
	{
		Only,
		WithMessages
	}

	public enum EaseMessageCellTapEventType : uint
	{
		VideoBubbleTap,
		tLocationBubbleTap,
		tImageBubbleTap,
		tAudioBubbleTap,
		tFileBubbleTap,
		tCustomBubbleTap
	}

	[Native]
	public enum DXTextViewInputViewType : ulong
	{
		NormalInputType = 0,
		TextInputType,
		FaceInputType,
		ShareMenuInputType
	}

	public enum EaseRecordViewType : uint
	{
		TouchDown,
		TouchUpInside,
		TouchUpOutside,
		DragInside,
		DragOutside
	}

	public enum EMChatToolbarType : uint
	{
		Chat,
		Group
	}

	[Native]
	public enum EMEmotionType : ulong
	{
		Default = 0,
		Png,
		Gif
	}
}
