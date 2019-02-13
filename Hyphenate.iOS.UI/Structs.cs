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

    public static class DefineConstants
    {
        // DemoErrorCode.h
        public static readonly int EMErrorAudioRecordDurationTooShort = -100;
        public static readonly int EMErrorFileTypeConvertionFailure = -101;
        public static readonly int EMErrorAudioRecordStoping = -102;
        public static readonly int EMErrorAudioRecordNotStarted = -103;

        // EaseEmotionManager.h
        public static readonly string EASEUI_EMOTION_DEFAULT_EXT = "em_emotion";
        public static readonly string MESSAGE_ATTR_IS_BIG_EXPRESSION = "em_is_big_expression";
        public static readonly string MESSAGE_ATTR_EXPRESSION_ID = "em_expression_id";

        // EaseSDKHelper.h
        /** @brief 登录状态变更的通知 */
        public static readonly string NOTIFICATION_LOGINCHANGE = "loginStateChange";
        /** @brief 实时音视频呼叫 */
        public static readonly string NOTIFICATION_MAKE1V1CALL = "EMMake1v1Call";
        /** @brief 群组消息ext的字段，用于存放被@的环信id数组 */
        public static readonly string GroupMessageAtList      = "em_at_list";
        /** @brief 群组消息ext字典中，kGroupMessageAtList字段的值，用于@所有人 */
        public static readonly string GroupMessageAtAll       = "all";
        /** @brief 注册SDK时，是否允许控制台输出log */
        public static readonly string SDKConfigEnableConsoleLogger = "SDKConfigEnableConsoleLogger";
        /** @brief 使用的SDK是否为Lite版本(即不包含实时音视频功能) */
        public static readonly string EaseUISDKConfigIsUseLite = "isUselibHyphenateClientSDKLite";
    }
}
