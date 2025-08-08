using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoScrewSys.Base
{
    public static class LanguageManager
    {
        public static string CurrentCultureCode { get; private set; } = CultureInfo.CurrentUICulture.Name;

        /// <summary>
        /// 设置语言并刷新主窗体和所有用户控件的资源显示。
        /// mainForm - 你的主窗体（或任何顶级容器）
        /// userControls - 你已经创建并放到 panel/容器里的用户控件集合（formList）
        /// 注意：必须在 UI 线程调用（会访问控件属性）。
        /// </summary>
        public static void SetLanguage(string cultureCode, Form mainForm, IEnumerable<UserControl> userControls)
        {
            if (mainForm == null) throw new ArgumentNullException(nameof(mainForm));

            CurrentCultureCode = cultureCode;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureCode);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureCode);

            // 应用到主窗体（主窗体有自己的 .resx）
            ApplyResourcesForComponent(mainForm);

            // 应用到每个 UserControl（每个自定义控件通常有自己的 .resx）
            if (userControls != null)
            {
                foreach (var uc in userControls)
                {
                    if (uc == null) continue;
                    ApplyResourcesForComponent(uc);
                }
            }
        }

        /// <summary>
        /// 对某个组件（Form 或 UserControl 实例）应用资源，并递归处理子控件。
        /// </summary>
        private static void ApplyResourcesForComponent(Control component)
        {
            if (component == null) return;

            // 使用该组件类型的 ResourceManager（例如 MainFm 或 RunUI 的资源）
            var resources = new ComponentResourceManager(component.GetType());

            // 应用到组件自身（窗体 / usercontrol 的 "$this"）
            try
            {
                resources.ApplyResources(component, "$this");
            }
            catch
            {
                // 若没有 "$this" 资源可忽略
            }

            // 递归到子控件
            ApplyResourcesToChildren(component, resources);
        }

        /// <summary>
        /// 采用传入的 resources 对 parent 的子控件进行刷新。
        /// 对于子控件如果它是自定义 UserControl/Form，则切换为其自己的 ResourceManager。
        /// 对于普通控件则使用父资源（resources）并以 child.Name 为 key 应用资源。
        /// </summary>
        private static void ApplyResourcesToChildren(Control parent, ComponentResourceManager parentResources)
        {
            foreach (Control child in parent.Controls)
            {
                if (child == null) continue;

                var childType = child.GetType();

                // 判断子控件是否为自定义控件（通常需要它自己的资源）
                bool isCustomContainer =
                    typeof(UserControl).IsAssignableFrom(childType) ||
                    typeof(Form).IsAssignableFrom(childType) ||
                    // 或者该类型与 parent 同一程序集且不是 System.*（用于识别自定义控件）
                    (childType.Assembly == parent.GetType().Assembly &&
                     !(childType.Namespace?.StartsWith("System") ?? false));

                if (isCustomContainer)
                {
                    // 子控件有自己的资源文件（例如 UserControl 的 .resx），用它自己的 ResourceManager
                    var childRes = new ComponentResourceManager(childType);
                    try
                    {
                        childRes.ApplyResources(child, "$this");
                    }
                    catch
                    {
                        // ignore
                    }

                    // 递归使用子控件自己的 ResourceManager
                    ApplyResourcesToChildren(child, childRes);
                }
                else
                {
                    // 对普通控件：使用父资源管理器，以 child.Name 为 key
                    try
                    {
                        parentResources.ApplyResources(child, child.Name);
                    }
                    catch (MissingManifestResourceException)
                    {
                        // 如果父资源里确实没有该 key，跳过（避免抛出）
                    }
                    catch
                    {
                        // 其他异常也忽略，继续刷新其它控件
                    }

                    // 继续递归，但仍使用父资源（因为这些子控件不属于独立的组件资源）
                    if (child.HasChildren)
                        ApplyResourcesToChildren(child, parentResources);
                }
            }
        }
        /// <summary>
        /// 根据传入语言代码（如 "zh-CN" 或 "en"），设置程序语言，
        /// 并刷新主窗体及所有用户控件的资源显示。
        /// 这个函数适合程序启动时调用，语言从配置文件（Settings）读取后传入。
        /// </summary>
        /// <param name="cultureCode">语言代码，如 "zh-CN"、"en"</param>
        /// <param name="mainForm">主窗体实例</param>
        /// <param name="userControls">所有用户控件列表</param>
        public static void ApplyLanguage(string cultureCode, Form mainForm, IEnumerable<UserControl> userControls)
        {
            if (mainForm == null) throw new ArgumentNullException(nameof(mainForm));
            if (string.IsNullOrWhiteSpace(cultureCode)) cultureCode = "zh-CN";

            ApplyResourcesForComponent(mainForm);

            if (userControls != null)
            {
                foreach (var uc in userControls)
                {
                    if (uc == null) continue;
                    ApplyResourcesForComponent(uc);
                }
            }
        }
        public static void SetCurrentCulture(string cultureCode)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureCode);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureCode);
        }
    }

}
